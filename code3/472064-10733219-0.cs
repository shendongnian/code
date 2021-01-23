    using System;
    using System.Threading;
    
    namespace test
    {
    	class something
    	{
    		public String Name;
    	}
    	
        class Program
        {
    		private delegate bool TryableFunction(String s);
    		
    		private static bool TryUntillOk(TryableFunction f, String s, int howoften, int sleepms)
    		{
    			while (howoften-->0)
    			{
    				if (f(s)) return true;
    				Thread.Sleep(sleepms);
    			}
    			return false;
    		}
    		
            static void Main(string[] args)
            {
    			something bar=new something();
    			
    			bar.Name="Jane Doe";
    			bool succeeded = TryUntillOk(bar.Name.Equals,"John Doe", 15, 100);
    			Console.WriteLine("Succeeded with '{0}': {1}",bar.Name,succeeded);
    
    			bar.Name="John Doe";
    			succeeded = TryUntillOk(bar.Name.Equals,"John Doe", 15, 100);
    			Console.WriteLine("Succeeded with '{0}': {1}",bar.Name,succeeded);
    		}
    		
    		
    	}
    }
