    // set up domain context
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    // validate credentials
    bool isValid = ctx.ValidateCredentials("myuser", "mypassword");
    // find a user
    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "SomeUserName");
    
    if(user != null)
    {
       // do something here....	    
    }
    
