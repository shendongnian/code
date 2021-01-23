    GenericIdentity userIdentity = new GenericIdentity((FormsIdentity)HttpContext.Current.User.Identity.Name);
    
    string[] roles = <some roles> 
    GenericPrincipal userPrincipal = new GenericPrincipal(userIdentity, roles);
    Context.User = userPrincipal;
