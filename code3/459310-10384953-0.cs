    System.Web.HttpContext ctx = System.Web.HttpContext.Current;
            
    Configuration config;
    if (ctx != null)
        config = WebConfigurationManager.OpenWebConfiguration(ctx.Request.ApplicationPath);
