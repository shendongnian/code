    public bool DoesUserExist(string userName)
    {
        bool exists = false;
        try
        {
        using (var domainContext = new PrincipalContext(ContextType.Domain, "DOMAIN"))
        {
            using (var foundUser = UserPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, userName))
            {
                exists = true;
            }
          }
        }
        catch(exception ex)
        {
          //Exception could occur if machine is not on a domain
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
