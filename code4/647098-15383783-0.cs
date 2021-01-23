    private DateTime start_time
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        start_time = DateTime.Now;
    }
    protected void Application_EndRequest(object sender, EventArgs e)
    {
        var duration = DateTime.Now - start_time;
        Response.Write("...");
    }
