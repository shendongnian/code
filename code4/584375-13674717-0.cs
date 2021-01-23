    public abstract class BasePage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
        	string cTheFile = HttpContext.Current.Request.Path;
        
        	// here select what part of that string you won to check out
        	if(!GetAuthenticatedRolesByModuleName(cTheFile))
        	{
        		// some how avoid the crash if call the same page again
        		if(!cTheFile.EndsWith("Default.aspx"))
        		{    	
    	    		Response.Redirect("Default.aspx", true);
    	    		return ;
        		}
        	}
        
        	// continue with the rest of the page
        	base.OnPreInit(e);
    	}
    }
