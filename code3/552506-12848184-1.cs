    protected void Application_Start(object sender, EventArgs e)
    {
        try
        {
            SomeStaticGlobalClass.Domain = System.Configuration.ConfigurationManager.AppSettings["Domain"];
        }
        catch { }
    }
