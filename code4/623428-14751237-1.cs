    public IEnumerable<OpenCall> OpenCalls()
    {
        return OpenCalls(null, null);
    }
    public IEnumerable<OpenCall> OpenCalls(DateTime? start, DateTime? endd)
    {
        //if (!start.HasValue) ... etc.
        return something_slightly_different;
    }
