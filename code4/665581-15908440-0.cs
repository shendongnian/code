    public static void Trace(string Output)
    {
        Trace.WriteLine(Output);
        if(OutputToConsole) Console.WriteLine(Output);
    }
