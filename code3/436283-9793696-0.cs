    public bool IsUserInGroup(string userName, string groupName)
    {
        var context = new PrincipalContext(ContextType.Machine);
        using (var searcher = new PrincipalSearcher(new UserPrincipal(context) { SamAccountName = userName }))
        {
            var user = searcher.FindOne() as UserPrincipal;
            return user.IsMemberOf(context, IdentityType.SamAccountName, groupName);
        }
    }
