    public void MainFunc()
    {
        InnerFunc();
        Console.WriteLine("InnerFunc finished");
    }
    public void InnerFunc()
    {
        // This causes InnerFunc to return execution to MainFunc,
        // which will display "InnerFunc finished" immediately.
        string urlContents = await client.GetStringAsync();
        // Do stuff with urlContents
    }
    public void InnerFunc()
    {
        // "InnerFunc finished" will only be displayed when InnerFunc returns,
        // which may take a while since GetString is a costly call.
        string urlContents = client.GetString();
        // Do stuff with urlContents
    }
