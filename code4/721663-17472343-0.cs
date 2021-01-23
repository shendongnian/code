    try
    {
    }
    catch (Exception ex)
    {
        var stackTrace = new StackTrace(ex, true);
        var frame = stackTrace.GetFrame(0);
        var line = frame.GetFileLineNumber();
        var method = frame.GetMethod();
    }
