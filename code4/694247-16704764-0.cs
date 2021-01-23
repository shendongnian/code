        try
        {
            Console.WriteLine("Executing the try statement.");
            throw new NullReferenceException();
        }
        catch (SomeOtherException e)
        {
            Console.WriteLine("{0} Caught exception #1.", e);
        }       
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
        Console.WriteLine("Executing stuff after try/catch/finally.");
