    Debug.Assert(Request.IsSecureConnection, "The IsAuthenticated will fail.");
    if (!HttpContext.Current.User.Identity.IsAuthenticated)
    {
    	Server.Transfer(@"~/Views/Public/Unauthorised.aspx");
    	return;
    }
