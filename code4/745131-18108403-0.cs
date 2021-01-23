    var now = DateTime.UtcNow.ToLocalTime();
    
    var ticket = new FormsAuthenticationTicket(
                    1, /*version*/
                    MemberID,
                    now,
                    now.Add(_expirationTimeSpan),
                    createPersistentCookie,
                    TokenID, /*custom data*/
                    FormsAuthentication.FormsCookiePath);
    
    var encryptedTicket = FormsAuthentication.Encrypt(ticket);
    
    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
    {
       HttpOnly = true,
       Secure = FormsAuthentication.RequireSSL,
       Path = FormsAuthentication.FormsCookiePath
    };
    
    if (ticket.IsPersistent)
    {
       cookie.Expires = ticket.Expiration;
    }
    if (FormsAuthentication.CookieDomain != null)
    {
       cookie.Domain = FormsAuthentication.CookieDomain;
    }
    
    _httpContext.Response.Cookies.Add(cookie);
