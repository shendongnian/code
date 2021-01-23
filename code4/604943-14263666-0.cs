    static void unhandled()
    {
        try
        {
            throw new Exception();
        }
        finally
        {
            Console.WriteLine("finally");
        }
    }
    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
        try
        {
            unhandled();
        }
        catch ( Exception )
        {
            // squash it
        }
    }
