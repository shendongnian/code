    using System;
    
    namespace TimeZoneSample
    {
    	public static class Program
    	{
    		public static void Main()
    		{
    			DateTime t = DateTime.Parse("3/10/2013 2:02:11 AM");
    			Console.WriteLine(t);
    			Console.WriteLine(t.ToUniversalTime());
    			Console.WriteLine(t.ToUniversalTime().ToLocalTime());
    		}
    	}
    }
