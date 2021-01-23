    // set up domain context
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        // find the group in question
        GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "MainGroup");
  
        // if found....
        if (group != null)
        {
            // iterate over members
            foreach (Principal p in group.GetMembers())
            {
                 Console.WriteLine("{0}: {1}", p.StructuralObjectClass, p.DisplayName);
                 // do whatever you need to do to those members
                 // if you need to find the groups that are members of 'MainGroup'  
                 GroupPrincipal group = p as GroupPrincipal;
                 if(group != null)
                 {
                     // now you have a group that is member of 'MainGroup' - do what you need here
                 }
            }
        }
    }
