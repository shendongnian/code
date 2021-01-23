    
    protected void Session_start()
    {
        // starting a session and already authenticated means we have an old cookie
        var existingUser = System.Web.HttpContext.Current.User;
        if (existingUser != null && existingUser.Identity.Name != "")
        {
            // clear any existing cookies
            IAuthenticationManager authMgr = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            authMgr.SignOut("MyCookieType")
            // manually clear user from HttpContext so Authorize attr works
            System.Web.HttpContext.Current.User = new ClaimsPrincipal(new ClaimsIdentity());
        }
    }
