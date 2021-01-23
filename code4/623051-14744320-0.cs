    // set up domain context
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        // find your user
        UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "SomeUserName");
        
        if(user != null)
        {
            // find the group in question
            GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "TestDelete");
      
            // if found....
            if (group != null)
            {
                // add user to group
                group.Members.Add(user);
                group.Save();
            }
        }
    }
    
