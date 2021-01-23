    public void Init(HttpApplication context)
    {
        context.BeginRequest += (Application_BeginRequest);
    }
    private void Application_BeginRequest(object source, EventArgs e)
    {
        var context = ((HttpApplication) source).Context;
        var ipAddress = context.Request.UserHostAddress;        
    }
