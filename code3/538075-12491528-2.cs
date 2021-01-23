    if (department != "")
    {
       rootDSE = new DirectoryEntry(
         "LDAP://OU=" + department + ",OU=Users,dc=corp,dc=local", username, password);
    }
    else
    {
       rootDSE = new DirectoryEntry(
          "LDAP://OU=Users,OU=" + ou + ",dc=corp,dc=local", username, password);
    }
    DirectorySearcher ouSearch = new DirectorySearcher(rootDSE);
    ouSearch.PageSize = 1001;
    ouSearch.Filter = "(objectClass=group)";
    ouSearch.SearchScope = SearchScope.Subtree;
    ouSearch.PropertiesToLoad.Add("name");
    SearchResultCollection allOUS = ouSearch.FindAll();
    foreach (SearchResult oneResult in allOUS)
    {
        dt.Rows.Add(oneResult.Properties["name"][0].ToString());
    }
    rootDSE.Dispose();
    return dt;
