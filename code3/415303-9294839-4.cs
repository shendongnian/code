    public void ReportException(Exception exception)
    {
        if (Debugger.IsAttached)
        {
            DebugHelper.PrintExceptionToConsole(exception);
            Debugger.Break();
        }
        // ...
    }
