    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "mine.domain.com");
    GroupPrincipal grp = GroupPrincipal.FindByIdentity(ctx, IdentityType.Name, "myADGroup");
    if (grp != null)
    {
        foreach (UserPrincipal user in grp.GetMembers(true))
        {
            Console.WriteLine("User: {0}", user.Name);
            foreach (Principal userGroup in user.GetGroups(ctx))
            {
                Console.WriteLine("   - Member of Group: {0}", userGroup.Name);
            }
        }
    }
