    public static void RenewAuthenticationTicket(HttpContext currentContext)
    {
        var authenticationTicketCookie = currentContext.Request.Cookies["AuthTicketNameHere"];
        var oldAuthTicket = FormsAuthentication.Decrypt(authenticationTicketCookie.Value);
        var newAuthTicket = oldAuthTicket;
        newAuthTicket = FormsAuthentication.RenewTicketIfOld(oldAuthTicket); //This triggers the regular sliding expiration functionality.
        if (newAuthTicket != oldAuthTicket)
        {
            //Add the renewed authentication ticket cookie to the response.
            authenticationTicketCookie.Value = FormsAuthentication.Encrypt(newAuthTicket);
            authenticationTicketCookie.Domain = FormsAuthentication.CookieDomain;
            authenticationTicketCookie.Path = FormsAuthentication.FormsCookiePath;
            authenticationTicketCookie.HttpOnly = true;
            authenticationTicketCookie.Secure = FormsAuthentication.RequireSSL;
            currentContext.Response.Cookies.Add(authenticationTicketCookie);
            //Here we have the opportunity to do some extra stuff.
            SetAuthenticationExpirationTicket(currentContext);
        }
    }
