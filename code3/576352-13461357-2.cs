    public static void SetUserInfo(string userName, string property, string value)
    {
        var dsDirectoryEntry = new DirectoryEntry("LDAP://xxxx/DC=xx,DC=xxx", "ADusername", "ADpassword");
        var dsSearch = new DirectorySearcher(dsDirectoryEntry) { Filter = "(&(objectClass=user)(SAMAccountName=" + userName + "))" };
        var dsResults = dsSearch.FindOne();
        var myEntry = dsResults.GetDirectoryEntry();
        myEntry.Properties[property].Value = value;
        myEntry.CommitChanges();
    }
