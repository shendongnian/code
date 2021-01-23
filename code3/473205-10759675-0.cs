    [Conditional("TRACE")]
    public WriteTraceLine(string message)
    {
         Trace.WriteLine(message);
    }
