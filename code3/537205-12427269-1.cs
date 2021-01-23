    using System;
    using System.Diagnostics;
    class Program
    {
    	public static void Main(string[] args)
    	{
    		const int m = 1000000;
    		DateTime d;
    
    		Stopwatch s1 = Stopwatch.StartNew();
    		for (int i = 0; i < m; i++)
    		{
    			d=DateTime.Now;
    		}
    		s1.Stop();
    
    		Stopwatch s2 = Stopwatch.StartNew();
    		for (int i = 0; i < m; i++)
    		{
    			DateTime.Now.AddSeconds(10);
    		}
    		s2.Stop();
    
    		Console.WriteLine("{0}, {1}",s1.ElapsedMilliseconds,s2.ElapsedMilliseconds);
    		Console.Read();
    	}
    }
