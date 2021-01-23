    public string GetStringData()
    {
        string ret;
        MyAsyncMethodWithReturnParameter( (String s) => { ret = s; } ).Wait();
        return ret;
    }
    public async Task MyAsyncMethodWithReturnParameter(Action<String> informReturn)
    {
        informReturn("test");
    }
