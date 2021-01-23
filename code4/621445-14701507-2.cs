    protected void Application_PostAuthenticateRequest(object sender, EventArgs args)
    {
        var application = (HttpApplication)sender;
        var context = application.Context;
    
        if (context.User != null || !context.User.Identity.IsAuthenticated) return; // user not authenticated, so you don't need to do anything else
        var formsIdentity = context.User.Identity as FormsIdentity;
        if (formsIdentity == null) return; // not a forms identity, so we can't do any further processing
   
        var ticket = formsIdentity.Ticket;
        // now you can access ticket.UserData
        // to add your own values to UserData, you'll have to create the ticket manually when you first log the user in
        var values = ticket.UserData.Split('|');
        // etc.
        // I'll pretend the second element values is a comma-delimited list of roles for the user, just to illustrate my point
        var roles = values[1].Split(',');
    
        
        context.User = new GenericPrincipal(new GenericIdentity(ticket.Name, "Forms"), roles); 
    }
