    protected void StripQueryStringAndRedirect(System.Web.HttpContextBase httpContext, string[] keysToRemove)
    {
    	var queryString = new NameValueCollection(httpContext.Request.QueryString);
    
    	foreach (var key in keysToRemove)
    	{
    		queryString.Remove(key);
    	}
    
    	var newQueryString = "";
    
    	for (var i = 0; i < queryString.Count; i++)
    	{
    		if (i > 0) newQueryString += "&";
    		newQueryString += queryString.GetKey(i) + "=" + queryString[i];
    	}
    
    	var newPath = httpContext.Request.Path + (!String.IsNullOrEmpty(newQueryString) ? "?" + newQueryString : String.Empty);
    
    	if (httpContext.Request.Url.PathAndQuery != newPath)
    	{
    		httpContext.Response.Redirect(newPath, true);
    	}
    }
