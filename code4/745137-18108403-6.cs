    // In Global.asax.cs
    void Application_AuthenticateRequest(object sender, EventArgs e)
    {
       HttpCookie decryptedCookie = 
          Context.Request.Cookies[FormsAuthentication.FormsCookieName];
    
       FormsAuthenticationTicket ticket = 
          FormsAuthentication.Decrypt(decryptedCookie.Value);
        
       var identity = new GenericIdentity(ticket.Name);
       var principal = new GenericPrincipal(identity, null);
        
       HttpContext.Current.User = principal;
       Thread.CurrentPrincipal =HttpContext.Current.User;
    }
        
    // In action method, how to check whether user is logged in 
    if (User.Identity.IsAuthenticated)
    {
                        
    }
