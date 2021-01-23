    public static void Application_Error(object sender, EventArgs e)
    {
    	var httpContext = ((MvcApplication)sender).Context;
    
        // ignore if it is a programatically raised 404
    	if(httpContext.Items["Programmatic404"] != null && bool.Parse(httpContext.Items["Programmatic404"].ToString()))
    		return;
    
    	// else, Log the exception
    }
