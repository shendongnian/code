    public string GetStringData()
    {
        return MyMethodWithReturnParameterAsync().GetAwaiter().GetResult();
    }
    public async Task<String> MyMethodWithReturnParameterAsync()
    {
        return "test";
    }
