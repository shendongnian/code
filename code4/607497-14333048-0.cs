    public static bool IsUserInGroup(string dc, string User, string group) 
    {
        bool found = false;
        PrincipalContext ctx = new PrincipalContext(ContextType.Domain, dc);
        GroupPrincipal p = GroupPrincipal.FindByIdentity(ctx, group);
        UserPrincipal u = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, User);
        found = p.GetMembers(true).Contains(u);
        p.Dispose();
        u.Dispose();
        return found; 
    }
