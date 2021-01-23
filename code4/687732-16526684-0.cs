    public static void AddToLog(
        Guid someID, LogArea myLogger, string message, params object[] parameters)
    {
        foreach(object p in parameters)
        {
            Console.WriteLine(p);
        }
    }
