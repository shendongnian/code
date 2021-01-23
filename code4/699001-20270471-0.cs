    /// <summary>
    /// Checks to see if the current request can skip authorization, either because context.SkipAuthorization is true,
    /// or because UrlAuthorizationModule.CheckUrlAccessForPrincipal() returns true for the current request/user/url.
    /// </summary>
    /// <returns></returns>
    public bool DoesUrlRequireAuth()
    {
    	HttpContext context = HttpContext.Current;
    	string path = context.Request.AppRelativeCurrentExecutionFilePath;
    	return context.SkipAuthorization ||
            UrlAuthorizationModule.CheckUrlAccessForPrincipal(
                path, context.User, context.Request.RequestType);
    }
    
    void Application_AuthorizeRequest(object sender, EventArgs e)
    {
        if (DoesUrlRequireAuth())
        {
            // request protected by forms auth
        }
        else
        {
            // do your http basic auth code here
        }
    }
    
