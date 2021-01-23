    public async Task MyMethodAsync()
    {
    }
    public string GetStringData()
    {
        MyMethodAsync().GetAwaiter().GetResult();
        return "test";
    }
