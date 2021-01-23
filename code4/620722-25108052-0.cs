    /// <summary>
    /// Read web cookies
    /// </summary>
    public static CookieContainer ReadCookies(this HttpResponseMessage response)
    {
    	var pageUri = response.RequestMessage.RequestUri;
    
    	var cookieContainer = new CookieContainer();
    	IEnumerable<string> cookies;
    	if (response.Headers.TryGetValues("set-cookie", out cookies))
    	{
    		foreach (var c in cookies)
    		{
    			cookieContainer.SetCookies(pageUri, c);
    		}
    	}
    
    	return cookieContainer;
    }
