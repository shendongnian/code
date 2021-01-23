    public static DateTime? GetLastPasswordSet(string domain, string userName)
    {
        using (var context = new PrincipalContext(ContextType.Domain, domain))
        {
            var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, userName);
            return userPrincipal.LastPasswordSet;
        }
    }
