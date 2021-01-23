    private IList<string> GetUserGroupsLDAP(string samAccountName)
    {
        var groupList = new List<string>();
        var domainConnection = new DirectoryEntry("LDAP://" + serverName, serverUser, serverUserPassword); // probably you don't need username and password
        var samSearcher = new DirectorySearcher();
        samSearcher.SearchRoot = domainConnection;
        samSearcher.Filter = "(samAccountName=" + samAccountName + ")";
        var samResult = samSearcher.FindOne();
        if (samResult != null)
        {
            var theUser = samResult.GetDirectoryEntry();
            theUser.RefreshCache(new string[] { "tokenGroups" });
            var sidSearcher = new DirectorySearcher();
            sidSearcher.SearchRoot = domainConnection;
            sidSearcher.PropertiesToLoad.Add("name");
            sidSearcher.Filter = CreateFilter(theUser);
            foreach (SearchResult result in sidSearcher.FindAll())
            {
                groupList.Add((string)result.Properties["name"][0]);
            }
        }
        return groupList;
    }
    private string CreateFilter(DirectoryEntry theUser)
    {
        string filter = "(|";
        foreach (byte[] resultBytes in theUser.Properties["tokenGroups"])
        {
            var SID = new SecurityIdentifier(resultBytes, 0);
            filter += "(objectSid=" + SID.Value + ")";
        }
        filter += ")";
        return filter;
    }
