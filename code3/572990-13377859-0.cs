    public void DoProcessing()
    {
        TraceMessage("Something happened.");
    }
    public void TraceMessage(string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        Trace.WriteLine("message: " + message);
        Trace.WriteLine("member name: " + memberName);
        Trace.WriteLine("source file path: " + sourceFilePath);
        Trace.WriteLine("source line number: " + sourceLineNumber);
    }
