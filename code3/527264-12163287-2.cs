    static void Main(string[] args)
    {
        try
        {
            CatchTest();
        }
        catch (Exception)
        {
        }
    }
    private static void CatchTest()
    {
        int i = 0;
        try
        {
            int j = 1 / i; // Generate a divide by 0 exception.    
        }
        finally
        {
            Console.Out.WriteLine("Finished");
            Console.In.ReadLine();
        }
    }
