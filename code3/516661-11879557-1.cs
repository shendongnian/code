    public override Task ProcessRequestAsync(HttpContext context)
    {
        return new AdRequest().ProcessRequest();
    }
    public Task<String> ProcessRequest()
    {
        return Task.Return("foo");
    }
