    protected void Application_PostAuthenticateRequest(object sender, EventArgs args)
    {
        var application = (HttpApplication)sender;
        var context = application.Context;
    
        if (context.User != null || !context.User.Identity.IsAuthenticated) return; // user not authenticated, so you don't need to do anything else
    
        // Here, you'd process the existing context.User.Identity.Name and split out the values you need. that part is up to you. in my example here, I'll just show you creating a new principal
        var oldUserName = context.User.Identity.Name;
        context.User = new GenericPrincipal(new GenericIdentity(oldUserName, "Forms"), new string[0]); 
    }
