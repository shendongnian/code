    // set up domain context
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    // find a user
    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "SamAccountName");
    
    if(user != null)
    {
        if(user.IsAccountLockedOut())
        {       
            // do something here....	    
        }
    }
    
