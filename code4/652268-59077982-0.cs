    public async Task MyAsyncMethod()
    {
    }
    public string GetStringData()
    {
        // Note: Wait will wrap any exception into AggregateException
        MyAsyncMethod().Wait();
        return "test";
    }
