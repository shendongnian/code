    public bool DoesUserExist(string userName)
    {
        using (var domainContext = new PrincipalContext(ContextType.Domain, "DOMAIN"))
        {
            using (var foundUser = UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, userName))
            {
                return foundUser != null;
            }
        }
    }
