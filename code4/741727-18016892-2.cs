    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			SomeCode();
    		}
    
    		static void SomeCode()
    		{
    			object o = null;
    			switch (new Random().Next(0, 3))
    			{
    				case 0:
    					o = 3.0f;
    					break;
    				case 1:
    					o = 3.0d;
    					break;
    				case 2:
    					o = "hello";
    					break;
    			}
    			Action((dynamic)o); // notice dynamic here
    		}
    
    		static void Action(dynamic a)
    		{
    			Console.WriteLine("object");
    		}
    
    		static void Action(float a)
    		{
    			Console.WriteLine("float");
    		}
    		static void Action(int a)
    		{
    			Console.WriteLine("int");
    		}
    		static void Action(string a)
    		{
    			Console.WriteLine("string");
    		}
    	}
    }
