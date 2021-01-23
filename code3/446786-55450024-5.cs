    protected void Application_Error(object sender, EventArgs e)
    {
        //Catch Exception in Global place
        Exception exceptionObject = Server.GetLastError();
        try
        {
    		if (exceptionObject != null)
    		{
    			if (exceptionObject.InnerException != null)
    			{
    				exceptionObject = exceptionObject.InnerException;
    			}
    			switch (exceptionObject.GetType().ToString())
    			{
    				case "System.Threading.ThreadAbortException":
    				HttpContext.Current.Server.ClearError();
    				break;
    				default:
    				LogException(exceptionObject);//Custom method to log error
    				break;
    			}
    		}
    	}
    	catch { }//Avoiding further exception from exception handling
    }
 
