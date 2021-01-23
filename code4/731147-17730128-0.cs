    public static void LogWithPrefix(string message)
    {
        var prefix = GetPrefix();
        Log(prefix + message);
    }
    public static void Log(string message)
    {
        Console.WriteLine(message);
    }
