    public static string ChangePassword20(string adminUser, string adminPassword,
        string container, string domainController, string userName, string newPassword)
    {
        const AuthenticationTypes authenticationTypes = AuthenticationTypes.Secure |
            AuthenticationTypes.Sealing | AuthenticationTypes.ServerBind;
        
        DirectoryEntry searchRoot = null;
        DirectorySearcher searcher = null;
        DirectoryEntry userEntry = null;
        try
        {
            searchRoot = new DirectoryEntry(String.Format("LDAP://{0}/{1}", 
                domainController, container), 
                adminUser, adminPassword, authenticationTypes);
            searcher = new DirectorySearcher(searchRoot);
            searcher.Filter = String.Format("sAMAccountName={0}", userName);
            searcher.SearchScope = SearchScope.Subtree;
            searcher.CacheResults = false;
            SearchResult searchResult = searcher.FindOne(); ;
            if (searchResult == null) return "User Not Found In This Domain";
            userEntry = searchResult.GetDirectoryEntry();
            userEntry.Invoke("SetPassword", new object[] { newPassword });
            userEntry.CommitChanges();
            return "New password set";
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
        finally
        {
            if (userEntry != null) userEntry.Dispose();
            if (searcher != null) searcher.Dispose();
            if (searchRoot != null) searchRoot.Dispose();
        }
    }
