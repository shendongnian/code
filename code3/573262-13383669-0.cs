    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        if(DbHelper.SiteIsShutDown)
        {
            HttpContext.Current.Response.Redirect("SiteDown");
        }
    }
