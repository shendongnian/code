    protected void Session_End()
        {
        	// Clear the error on server. 
        	Server.ClearError(); 
        	Response.Clear(); 
        	 
    		RouteData routeData = new RouteData(); 
    		 
    		routeData.Values.Add("controller", "Account"); 
    		routeData.Values.Add("action", "Login"); 
    		 
    		 
    		// Call target Controller and pass the routeData. 
    		IController AccountMainController = new AccountController(); 
    		AccountMainController.Execute(new RequestContext( 
    				new HttpContextWrapper(Context), routeData));
        }
