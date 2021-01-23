    // set up domain context
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    // find a user
    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, User.Identity.Name);
    
    if(user != null)
    {
       // do something here ... like grabbing the GUID
       var userGuid = user.Guid;
    }
    
