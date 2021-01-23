    using System;
    class Class1
    {
        static int Main(string[] args)
        {
            try
            {
                int intReturnCode = 1;
                int intRandNumber;
    
                Random myRandom = new Random();
                intRandNumber = myRandom.Next(0,2);
                if(intRandNumber ==1)
                {
                    throw new Exception("ErrorError");      
                }
            }
            catch(Exception e)
            {
              // ...
            }
            finally
            {
                return intReturnCode;
            }
        }
    }
