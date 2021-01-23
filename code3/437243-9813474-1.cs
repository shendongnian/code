    HttpCookie _cookie = HttpContext.Current.Request.Cookies["customticket"];
    
    if(_cookie){
    
    _encryptedTicket = _cookie.Value;
    FormsAuthenticationTicket _ticket = FormsAuthentication.Decrypt(_encryptedTicket);
    
        if(!_ticket.Expired) {
            IIdentity _identity = new FormsIdentity(_ticket);
            IPrincipal _principal = new GenericPrincipal(_identity, new string[0]); //Identity plus string of roles.
        }
    }
    else{
    //dostuff
    }
