    GenericIdentity userIdentity = new GenericIdentity((FormsIdentity)HttpContext.Current.User.Identity.Name);
    
    string[] roles = { "rolename1", "rolename2", "rolename3" };
    GenericPrincipal userPrincipal = new GenericPrincipal(userIdentity, roles);
    Context.User = userPrincipal;
