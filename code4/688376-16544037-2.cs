    protected virtual void Application_EndRequest()
    {
        var key = "MyDb_" + HttpContext.Current.GetHashCode().ToString("x")
                          + Thread.CurrentContext.ContextID.ToString();
        var context = HttpContext.Current.Items[key] as MyDbContext;
    
        if (context != null)
        {
            context.Dispose();
        }
    }
