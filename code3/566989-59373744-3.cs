    public void ProcessRequest(HttpContext context)
    {
    	string requestData, alertMessage;
    	using (var reader = new StreamReader(context.Request.InputStream))
    	{
    		requestData = reader.ReadToEnd();
    	}
    	/* -1: unauthorized;
    	 * -2: authorized, but no information about last request time;
    	 * -3: more than half session timeout, or not needed to inform user about session expiration;
    	 * >=0: lesser than half session timeout or if needed to inform user. The number reflects the value of total amount of minutes to session expiration. 
    	 */
    	int status = -1, idleTimeInMinutes = 0;
    	if (context.User?.Identity == null
    		|| !context.User.Identity.IsAuthenticated
    		|| context.Session == null
    		|| context.Session["SessionUserLastPageRequestTime"] == null)
    	{
    		status = -1;
    		alertMessage = "Session expired!";
    	}
    	else
    	{
    		DateTime now = MyApp.CommonUtils.GetServerDateTime();
    		var userLastPageRequest = (DateTime?)context.Session["SessionUserLastPageRequestTime"];
    		if (userLastPageRequest == null)
    		{
    			status = -2;
    			alertMessage = null;
    		}
    		else
    		{
    			var halfTimeout = TimeSpan.FromMinutes(context.Session.Timeout / 2);
    			TimeSpan idleTime = now.Subtract(userLastPageRequest.Value);
    			idleTimeInMinutes = (int)idleTime.TotalMinutes;
    			if (idleTime <= halfTimeout)
    			{
    				status = -3;
    				alertMessage = null;
    			}
    			else
    			{
    				status = context.Session.Timeout - idleTimeInMinutes;
    				/* Send time to session expiration only if 3 or lesser minutes remain */
    				if (status > 3)
    					status = -3;
    				/* If session expiration time's expanding (sliding expiration) has been done in some way */
    				else if (status < 0)
    					status = 0;
    				alertMessage = string.Format("Session Will Expire In {0} Minutes", status);
    			}
    		}
    	}
    	context.Response.Write(JsonConvert.SerializeObject(new { Status = status, Message = alertMessage }));
    	/* Remove new cookie to prevent sliding of session expiration time */
        if (requestData == "TIMEOUT_REQUEST")
    	    context.Response.Cookies.Remove(FormsAuthentication.FormsCookieName); /* by fact FormsAuthentication.FormsCookieName equals to ".ASPXAUTH" */
    }
