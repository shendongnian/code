    var traceManager = EnterpriseLibraryContainer.Current.GetInstance<TraceManager>();
    using (var tracer1 = traceManager.StartTrace("MyRequestId=" + GetRequestId().ToString()))
    using (var tracer2 = traceManager.StartTrace("ClientID=" + clientId))
    {
        DoSomething();
    }
    static void DoSomething()
    {
        var logWriter = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();
        logWriter.Write("doing something", "General");
        DoSomethingElse("ABC.txt");
    }
    static void DoSomethingElse(string fileName)
    {
        var logWriter = EnterpriseLibraryContainer.Current.GetInstance<LogWriter>();
        // Oops need to log
        LogEntry logEntry = new LogEntry()
        {
            Categories = new string[] { "General" },
            Message = "requested file not found",
            ExtendedProperties = new Dictionary<string, object>() { { "filename", fileName } }
        };
        logWriter.Write(logEntry);
    }
