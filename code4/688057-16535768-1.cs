    if(HttpContext.Current.User == null || HttpContext.Current.User.Identity == null || !HttpContext.Current.User.Identity.IsAuthenticated)
    {
    		// now check if you have Session variables that you wish to remove.
    		if(Session["flag"] == "1")
    		{
    			// remove your session data   		
    		
    		}    
    }
