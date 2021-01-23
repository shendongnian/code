    protected void Application_AuthenticateRequest(Object sender, EventArgs e)
    {
    	// αυτό είναι το path...
    	string cTheFile = HttpContext.Current.Request.Path;
    	
    	// here select what part of that string you won to check out
    	if(!GetAuthenticatedRolesByModuleName(cTheFile))
    	{
    		// some how avoid the crash if call the same page again
    		if(!cTheFile.EndsWith("Default.aspx"))
    		{    	
    			Response.Redirect("Default.aspx", true);
    			Response.End();
    			
    			return ;
    		}
    	}
    }		
