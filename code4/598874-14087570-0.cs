    var authTicket = new FormsAuthenticationTicket(1, //version
        login.UserName, // user name
        DateTime.Now, //creation
        DateTime.Now.AddMinutes(30), //Expiration
        true, //Persistent
        userId);
        var encTicket = FormsAuthentication.Encrypt(authTicket);
        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
