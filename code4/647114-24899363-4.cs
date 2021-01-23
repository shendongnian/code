    protected void Application_Error(object sender, EventArgs e)
    {
    	var exception = Server.GetLastError();
    	if (exception != null)
    	{
    		Response.Clear();
    		HttpException httpException = exception as HttpException;
    		RouteData routeData = new RouteData();
    		routeData.Values.Add("controller", "Error");
    		if (httpException == null)
    		{
    			routeData.Values.Add("action", "Unknown");
    		}
    		else
    		{
    			switch (httpException.GetHttpCode())
    			{
    				case 404:				// Page not found.
    					routeData.Values.Add("action", "NotFound");
    					break;
    
    				default:
    					routeData.Values.Add("action", "Unknown");
    					break;
    			}
    		}
    
    		// Pass exception details to the target error View.
    		routeData.Values.Add("Error", exception);
    		// Clear the error on server.
    		Server.ClearError();
    		// Avoid IIS7 getting in the middle
    		Response.TrySkipIisCustomErrors = true;
            // Ensure content-type header is present
            Response.Headers.Add("Content-Type", "text/html");
    		// Call target Controller and pass the routeData.
    		IController errorController = new ErrorController();
    		errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
    	}
    }
