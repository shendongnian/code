    public string GetStringData()
    {
        return MyAsyncMethodWithReturnParameter().GetAwaiter().GetResult();
    }
    public async Task<String> MyAsyncMethodWithReturnParameter()
    {
        return "test";
    }
