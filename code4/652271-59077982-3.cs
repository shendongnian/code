    public async Task MyAsyncMethod()
    {
    }
    public string GetStringData()
    {
        MyAsyncMethod().GetAwaiter().GetResult();
        return "test";
    }
