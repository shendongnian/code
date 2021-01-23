    DirectoryEntry dEntryhighlevel = new DirectoryEntry("LDAP://CN=Users,OU=MyOu,OU=Clients,OU=Home,DC=bridgeTech,DC=net");
    DirectorySearcher dSearcher = new DirectorySearcher();
    //filter just user objects
    dSearcher.Filter = "(objectClass=user)";
    dSearcher.PageSize = 1000;
    SearchResultCollection resultCollection = dirSearcher.FindAll();
    foreach (SearchResult userResults in resultCollection )
    {
        string Last_Name = userResults .Properties["sn"][0].ToString();
        string First_Name = userResults .Properties["givenname"][0].ToString();
        string userName = userResults .Properties["samAccountName"][0].ToString();
        string Email_Address = userResults .Properties["mail"][0].ToString();
        OriginalList.Add(Last_Name + "|" + First_Name + "|" + userName + "|" + Email_Address);
    }
