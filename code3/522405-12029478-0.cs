    // set up domain context
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
    // find a user
    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "SomeUserName");
    // find the group in question
    GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "YourGroupNameHere");
    if(user != null)
    {
       // check if user is member of that group
       if (user.IsMemberOf(group))
       {
         // do something.....
       } 
    }
    
