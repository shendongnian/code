    public override void OnAuthorization(HttpActionContext actionContext)
    {
        // the only change I made is use the custom context builder from step 3:
        OAuthContext context = 
            new WebApiOAuthContextBuilder().FromHttpRequest(actionContext.Request);
        try
        {
            provider.AccessProtectedResourceRequest(context);
                
            // do nothing here
        }
        catch (OAuthException authEx)
        {
            // the OAuthException's Report property is of the type "OAuthProblemReport", it's ToString()
            // implementation is overloaded to return a problem report string as per
            // the error reporting OAuth extension: http://wiki.oauth.net/ProblemReporting
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                   RequestMessage = request, ReasonPhrase = authEx.Report.ToString()
                };
        }
    }
