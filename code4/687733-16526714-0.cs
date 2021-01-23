    public static void AddToLog(Guid someID, LogArea myLogger, string message, params object[] list)
    {
        // you can use it like an array
        Console.WriteLine("Guid:{0} Message:{1} Objects:{2}"
            , someID, message, string.Join(",", list));
    }
