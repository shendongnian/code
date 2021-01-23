    public void TraceMessage(string message,
            [CallerMemberName] string callingMethod = string.Empty,
            [CallerFilePath] string callingFilePath = string.Empty,
            [CallerLineNumber] int callingFileLineNumber = 0)
    {
        // Write out message
    }
