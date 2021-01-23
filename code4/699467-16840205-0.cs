    try
    {
        try
        {
            throw new ArgumentException();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("This is a custom exception");
            throw;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("This is for all exceptions, "+
            "including those caught and re-thrown above");
    }
