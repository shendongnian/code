    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
    	// get the authCookie
    	HttpCookie authCookie = Context.Request.Cookies[cookieName];
    	// if is null then the use is not Authendicated
    	if (null == authCookie && System.Web.HttpContext.Current.Session != null)
    	{
    		// now check if you have Session variables that you wish to remove.
    		if(System.Web.HttpContext.Current.Session["flag"] == "1")
    		{
    			// remove your session data
    		
    		
    		}	
    	}
    }
