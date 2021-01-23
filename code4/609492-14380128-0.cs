    public async Task ListeningAsync()
    {
        var context = await listener.GetContextAsync();
        HandleContext(context);
    }
    [Test]
    public async Task Test()
    {
        var listener = new AsyncHttpListener();
        await listener.ListeningAsync();
        try
        {
            new WebClient().DownloadString("http://localhost:8080/");
        }
        catch (Exception)
        {
        }
        listener.Close();
    }
