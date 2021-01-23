    using System;
    
    namespace Code.Without.IDE
    {
        public static class TryCatch
        {
    		public static void Main(string[] args)
    		{
                try
                {
                    try
                    {
                        throw new Exception("Ex01");
                    }
                    catch(Exception ex)
                    {
                        try
                        {
                            throw;
                        }
                        catch
                        {
                            Console.WriteLine("Exeption did not go anywhere");
                        }
                    }
                    Console.WriteLine("In try block");
                }
                catch
                {
                    Console.WriteLine("In catch block");
                }
    		}
    	}
    }
