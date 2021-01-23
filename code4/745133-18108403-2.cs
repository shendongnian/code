    HttpCookie decryptedCookie = 
       Context.Request.Cookies[FormsAuthentication.FormsCookieName];
    FormsAuthenticationTicket ticket = 
       FormsAuthentication.Decrypt(decryptedCookie.Value);
    
    var identity = new GenericIdentity(ticket.Name);
    var principal = new GenericPrincipal(identity, null);
    
    _httpContext.User = principal;
    Thread.CurrentPrincipal = _httpContext.User;
    // How to check whether user is logged in
    if (User.Identity.IsAuthenticated)
    {
                    
    }
