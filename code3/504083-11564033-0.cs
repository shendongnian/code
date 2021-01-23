    public override string[] GetRolesForUser(string username) 
    { 
        ArrayList results = new ArrayList(); 
 
        using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, null, domainContainer))
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, username);
                foreach (string acceptibleGroup in GroupsToInclude)
                {
                    GroupPrincipal p = GroupPrincipal.FindByIdentity(principalContext, IdentityType.SamAccountName, acceptibleGroup);
                    if (p.GetMembers().Contains(user))
                        results.Add(acceptibleGroup);
                }
            } 
 
        return results.ToArray(typeof(string)) as string[]; 
    }
