    if (!Request.IsLocal && !Request.IsSecureConnection)
    {
        const string SCHEME_HTTP = "http";
        const string SCHEME_HTTPS = "https";
        if (Request.Url.Scheme.Equals(SCHEME_HTTP, StringComparison.InvariantCultureIgnoreCase))
        {
            string redirectUrl = SCHEME_HTTPS + Request.Url.AbsoluteUri.Substring(SCHEME_HTTP.Length);
            Response.Redirect(redirectUrl);
        }
    }
 
