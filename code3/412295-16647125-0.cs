    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        Context.Response.AddHeader("Cache-Control", "max-age=0,no-cache,no-store");
        Context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Context.Response.Cache.SetMaxAge(TimeSpan.Zero);
        ....
    }
