    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static object[] ToObjectArray(List<float> a)
    		{
    			object[] b = new object[a.Count];
    			for (int i = 0; i < (a.Count); i++)
    				b[i] = (object)a[i];
    			return b;
    		}
    
    		static void Main(string[] args)
    		{
    			List<float> a = new List<float>();
    			a.Add(1.0f);
    			a.Add(2.0f);
    
    			string fmt = "{0} ft. {1} in.";
    			Console.WriteLine(String.Format(fmt, ToObjectArray(a)));
    
    			Console.ReadLine();
    
    		}
    	}
    }
