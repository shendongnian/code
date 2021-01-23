    protected void Application_End(object sender, EventArgs e)
    {
         if(!System.Web.HttpContext.Current.Request.IsLocal)
               core.cleanUpDB();
    }
