    private static TraceSwitch logSwitch = new TraceSwitch("logLevelSwitch",
        "This is your logLevelSwitch in the config file");
    
    public static void Main(string[] args)
    {
        // you can get its properties value then:
        Console.WriteLine("Trace switch {0} is configured as {1}",
            logSwitch.DisplayName,
            logSwitch.Level.ToString());
        // and you can use it like this:
        if (logSwitch.TraceError)
            Trace.WriteLine("This is an error");
        // or like this also:
        Trace.WriteLineIf(logSwitch.TraceWarning, "This is a warning");
    }
