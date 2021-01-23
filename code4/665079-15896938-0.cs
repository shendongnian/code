    protected void Application_BeginRequest()
    {
        MiniProfiler.Start();  
    }
    protected void Application_PostAuthorizeRequest(object sender, EventArgs e)
    {
        if (!DoTheCheckHere(this.Context))
        {
            MiniProfiler.Stop(discardResults: true);
        }
    }
    private bool DoTheCheckHere(HttpContext context)
    {
        // do your checks here
        return context.Request.User.IsInRole("Admin");
    }
