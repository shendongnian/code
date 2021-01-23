    public Task<string> FakeAsyncMethod()
    {
        var link = "http://google.com";
        var webclient = new WebClient();
        var t = new Task<string>(() => webclient.DownloadString(new Uri(link)));
        return t;
    }
    public async Task Index()
    {
        var a = FakeAsyncMethod();
        var b = FakeAsyncMethod();
        a.Start();
        b.Start();
        Task.WaitAll(a, b);
    }
    async void AsyncCall()
    {
        await Index();
    }
