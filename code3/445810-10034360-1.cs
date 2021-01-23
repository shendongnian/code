    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,
        username, DateTime.Now, DateTime.Now.AddMinutes(30),
        isPersist, "group");
    //I'll add more example code for the sake of completing the example
    string encryptTick = FormsAuthentication.Encrypt(authTicket);
    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                    encryptTick);
    if (isPersist)
        cookie.Expires = authTicket.Expiration;
    Response.Cookies.Add(cookie);
