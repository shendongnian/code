    private static void LogHelper(string text)
    {
        Trace.WriteLine(text);
        if(OutputToConsole) Console.WriteLine(text);
    }
