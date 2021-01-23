    protected void Session_End()
    {
    	// Clear the error on server. 
    	Server.ClearError(); 
    	Response.Clear(); 
    	 
        var routeData = new RouteData();
        routeData.Values["controller"] = "Account";
        routeData.Values["action"] = "Login";
    	
    	 
    	// Call target Controller and pass the routeData. 
        IController controller = new AccountController();
        var rc = new RequestContext(new HttpContextWrapper(Context), routeData);
        controller.Execute(rc);
    }
