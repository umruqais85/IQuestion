using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace anyType
{

    public static class here 
    {
        public static void start()
        {
        	IQuestion<string> q1=new stringQuestion();
		q1.setinfo("عاصمة العراق","بغداد");
		IQuestion<double> q2=new mathDblQuestion();
		q2.setinfo("5/2",(double)5/2);
		IQuestion<int> q3=new mathIntQuestion();
		q3.setinfo("5+6",5+6);
		
		bool f;
		Console.WriteLine("start");
		while(true)
		{
			f=askandcheck(q1);
			if(!f) break;
			f=askandcheck(q2);
			if(!f) break;
			f=askandcheck(q3);
			if(!f) break;
		}
		Console.WriteLine("end");
		
        }
        
        public static bool askandcheck<T>(IQuestion<T> q)
        {
        	Console.WriteLine("enter !! to exit");
        	Console.Write("Q: "+q.question+" ? ");
        	string ua=Console.ReadLine();
        	if(ua=="!!") return false;
        	if(q.checkanswer(ua))
        		Console.WriteLine("good answer");
        	else
        		Console.WriteLine("bad answer");
        	Console.WriteLine();
        	return true;
        }
    }
    
    public interface IQuestion<T>
    {
    	string question {get;}
    	T answer {get;}
    	void setinfo(string q,T s);
    	bool checkanswer(string ua);
    }
    public class stringQuestion : IQuestion<string>
    {
    	private string _question;
    	private string _answer;
    	public string question
    		=> _question;
    	public string answer
    		=> _answer;
    	public void setinfo(string q,string a)
    	{
    		_question=q;
    		_answer=a;
    	}
    	public bool checkanswer(string ua)
    	{
    		return _answer==ua;
    	}
    }
    public class mathDblQuestion : IQuestion<double>
    {
    	private string _question;
    	private double _answer;
    	public string question
    		=> _question;
    	public double answer
    		=> _answer;
    	public void setinfo(string q,double a)
    	{
    		_question=q;
    		_answer=a;
    	}
    	public bool checkanswer(string ua)
    	{
    		try
    		{
    			return _answer==double.Parse(ua);
    		}
    		catch(Exception ex)
    		{
    			return false;
    		}
    	}
    }
    public class mathIntQuestion : IQuestion<int>
    {
    	private string _question;
    	private int _answer;
    	public string question
    		=> _question;
    	public int answer
    		=> _answer;
    	public void setinfo(string q,int a)
    	{
    		_question=q;
    		_answer=a;
    	}
    	public bool checkanswer(string ua)
    	{
    		try
    		{
    			return _answer==int.Parse(ua);
    		}
    		catch(Exception ex)
    		{
    			return false;
    		}
    	}
    }
}
