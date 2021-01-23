    public List<string> getAllActiveUsers()
        {
            PrincipalContext oPrincipalContext = GetPrincipalContext();
            UserPrincipal oUserPrincipal = new UserPrincipal(oPrincipalContext) { Enabled = true };
            PrincipalSearcher oPrincipalSearcher = new PrincipalSearcher(oUserPrincipal);
            //Setting the search scope by going down to DirectorySearcher itself, as it's not possible to set this
            //via PrincipalSearcher directly
            ((DirectorySearcher)oPrincipalSearcher.GetUnderlyingSearcher()).SearchScope = SearchScope.OneLevel;
    
            List<string> allUsers = new List<string>();
    
            foreach (var found in oPrincipalSearcher.FindAll())
            {
                allUsers.Add(found.DisplayName.ToString());
            }
            allUsers.Sort();
            return allUsers;
        }
