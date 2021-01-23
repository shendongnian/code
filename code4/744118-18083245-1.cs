    // Attempt to login to the Security object using provided creds
    if (WebSecurity.Login(username, password, rememberMe)) 
    {
        Response.Cookies[0].Expires = DateTime.Now.AddDays(30); // Keep logged in for 30 days
        var returnUrl = Request.QueryString["ReturnUrl"];
        if (returnUrl.IsEmpty())
        {
            Response.Redirect("~/");
        } 
        else 
        {
            Context.RedirectLocal(returnUrl);
        }
    }
