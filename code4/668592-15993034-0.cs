    try 
    {
           try
            {
                var zero = 0;
                var s = 2 / zero;
            }
            catch (DivideByZeroException ex)
            { 
                // catch and convert exception
                throw new CustomException("Divide by Zero!!!!");
            }
        }
        catch (CustomException ex)
        {
            Console.Write("Exception");
            Console.ReadKey();
        }
