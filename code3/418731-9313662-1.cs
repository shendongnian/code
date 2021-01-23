    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
        1,
        user.UserName,
        DateTime.Now,
        DateTime.Now.AddMinutes(10),
        false,
        null);
    
    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
    
    this.Response.Cookies.Add(cookie);
