    using System;
    
    namespace testcs
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			try
    			{
    				try
    				{
    					foo();
    					foo();
    					foo();
    				}
    				catch
    				{
    					throw;
    				}
    			}
    			catch (Exception e)
    			{
    				Console.WriteLine(e.ToString());
    			}
    		}
    
    		private static void foo()
    		{
    			throw new Exception("oops");
    		}
    	}
    }
