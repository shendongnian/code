    try
    {
    using (HostingEnvironment.Impersonate())
    {
        using (var principalContext = new PrincipalContext(ContextType.Domain, "MYDOMAIN"))
        {
            using (var user = UserPrincipal.FindByIdentity(principalContext, userName))
            {
                if (user == null)
                {
                    Log.Debug("UserPrincipal.FindByIdentity failed for userName = " + userName + ", thus not authorized!");
                    isAuthorized = false;
                }
                                
                if (isAuthorized)
                {
                    firstName = user.GivenName;
                    lastName = user.Surname;
                    // so this code started failing:
                    // var groups = user.GetGroups();
                    // adGroups.AddRange(from @group in groups where 
                    // @group.Name.ToUpper().Contains("MYSEARCHSTRING") select @group.Name);
                    // so the following workaround, which calls, instead, 
                    // "user.IsMemberOf(group)", 
                    // appears to work (for now at least).  Will monitor for issues.
                    // test membership in SuperUsers
                    const string superUsersGroupName = "MyApp-SuperUsers";
                    using (var superUsers = GroupPrincipal.FindByIdentity(principalContext, superUsersGroupName))
                    {
                        if (superUsers != null && user.IsMemberOf(superUsers))
                            // add to the list of groups this user is a member of
                            // then do something with it later
                            adGroups.Add(superUsersGroupName);                                        
                    }
