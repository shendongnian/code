    public bool IsUserInGroup(string userName, string groupName)
    {
        using (var context = new PrincipalContext(ContextType.Machine))
        {
            using (var searcher = new PrincipalSearcher(new UserPrincipal(context) { SamAccountName = userName }))
            {
                using (var user = searcher.FindOne() as UserPrincipal)
                {
                    return user != null && user.IsMemberOf(context, IdentityType.SamAccountName, groupName);
                }
            }
        }
    }
