    DirectoryEntry de = new DirectoryEntry(LDAP Address,user,password);
    DirectorySearcher searcher = new DirectorySearcher(de);
    searcher.Filter = string.Format("(SAMAccountName={0})", user);
    SearchResult result = searcher.FindOne();
    bool isInGroup = false;
    if (result != null)
    {
        DirectoryEntry person = result.GetDirectoryEntry();
        PropertyValueCollection groups = person.Properties["memberOf"];
        foreach (string g in groups)
        {
            if(g.Equals(groupName))
            {
               isInGroup = true;
               break;
            }
        }
    }
    return isInGroup;
