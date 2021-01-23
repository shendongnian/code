    // Get context, based on currently logged on user PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, Environment.UserDomainName); // Search for the "Domain Users" group, with domain context GroupPrincipal group = GroupPrincipal.FindByIdentity(domainContext, IdentityType.SamAccountName, "Domain Users"); if(group != null) {
        List<Principal> members = null;
        members = group.GetMembers(false)
            .OrderBy(principal => principal.Name).ToList();
            List<Principal> Principals = members
            .OrderBy(a => a.Name.Split(',')[0])
            .ThenBy(a => a.Name.Split(',').Length>1? a.Name.Split(',')[1]:a.Name.Split(',')[0])
            .ThenBy(a => a.SamAccountName).ToList(); }
