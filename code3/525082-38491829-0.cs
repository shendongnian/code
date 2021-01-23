    var ad = new PrincipalContext(ContextType.Domain, _domain, _ldapPathOu);
                
    UserPrincipal user = UserPrincipal.FindByIdentity(ad, username);
    DirectoryEntry entry = user.GetUnderlyingObject() as DirectoryEntry;
    DirectorySearcher mySearcher = new DirectorySearcher(entry);
    SearchResultCollection results;
    mySearcher.PropertiesToLoad.Add("msDS-ResultantPSO");
    
    results = mySearcher.FindAll();
    
    if (results.Count >= 1)
    {
        string pso = results[0].Properties["msDS-ResultantPSO"][0].ToString();
        //do something with the pso..
        DirectoryEntry d = new DirectoryEntry(@"LDAP://corp.example.com/"+ pso);
        var searchForPassPolicy = new DirectorySearcher(d);
        searchForPassPolicy.Filter = @"(objectClass=msDS-PasswordSettings)";
        searchForPassPolicy.SearchScope = System.DirectoryServices.SearchScope.Subtree;
        searchForPassPolicy.PropertiesToLoad.AddRange(new string[] {"msDS-MaximumPasswordAge"});
        var x = searchForPassPolicy.FindAll();
        var maxAge = (Int64)x[0].Properties["msDS-MaximumPasswordAge"][0];
        var maxPwdAgeInDays = ConvertTimeToDays(maxAge);
    }
