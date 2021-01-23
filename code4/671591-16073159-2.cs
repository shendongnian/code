    if (!FormsAuthentication.CookiesSupported)
    {
        //If the authentication ticket is specified not to use cookie, set it in the Uri
        FormsAuthentication.SetAuthCookie(encrypetedTicket, createPersistentCookie);
    }
    else
    {
        //If the authentication ticket is specified to use a cookie, wrap it within a cookie.
        //The default cookie name is .ASPXAUTH if not specified 
        //in the <forms> element in web.config
        HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypetedTicket);
        //Set the cookie's expiration time to the tickets expiration time
        if(ticket.IsPersistent)
            authCookie.Expires =ticket.Expiration ;
        
        ////Set the cookie in the Response
        HttpContext.Current.Response.Cookies.Add(authCookie);
    }
