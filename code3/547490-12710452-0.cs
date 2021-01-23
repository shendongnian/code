    public bool DoesUserExist(string userName)
    {
        bool exists = false;
        using (var domainContext = new PrincipalContext(ContextType.Domain, "DOMAIN"))
        {
            using (var foundUser = UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, userName))
            {
                exists = true;
            }
        }
        using (var domainContext = new PrincipalContext(ContextType.Machine))
        {
            using (var foundUser = UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, userName))
            {
                exists = true;
            }
        }
       return exists;
    }
