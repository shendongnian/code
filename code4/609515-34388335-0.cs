A method around this problem could be to first search for Enabled Users using the PrincipalSearcher class and then use the Principal's method of IsMemberOf()
    List<string> users = List<string>();
    PrincipalContext pcContext = GetPrincipalContext();
    GroupPrincipal grp = GroupPrincipal.FindByIdentity(pcContext, IdentityType.Name, "Domain Users");
    UserPrincipal searchFilter = new UserPrincipal(pcContext){ Enabled = true }
    PrincipalSearcher searcher = new PrincipalSearcher(searchFilter);
    PrincipalSearchResult<Principal> results = searcher.FindAll();
    foreach (Principal user in results)
        if (user.IsMemberOf(grp))
            users.Add(user.SamAccountName);
