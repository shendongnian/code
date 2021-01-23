    public static void Main(string[] args)
    {
        try 
        {
            doStuff(null, 3);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
