    public override async Task ProcessRequestAsync(HttpContext context)
    {
        await new AdRequest().ProcessRequest();
    }
    public async Task<String> ProcessRequest()
    {
        return "foo";
    }
