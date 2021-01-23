    void Application_Error(object sender, EventArgs e)
    {
    	// Code that runs when an unhandled error occurs
    	if (HttpContext.Current != null)
    	{
    		var url = HttpContext.Current.Request.Url;
    		var page = HttpContext.Current.Handler as System.Web.UI.Page;
    	}
    }
