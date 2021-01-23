    List<string> groups = new List<string>();
    using (var root = new DirectoryEntry(ldapPath))
    {
        using(var srch = new DirectorySearcher(root, 
                       "(sAMAccountName=" + userName + ")"))
        {
            SearchResult res = srch.FindOne();
            if (res != null)
            {
                string dn = (string) res.Properties["distinguishedName"][0];
                string filter = String.Format(CultureInfo.InvariantCulture,
                    "(&(objectCategory=group)(groupType:1.2.840.113556.1.4.803:=2147483648)(member:1.2.840.113556.1.4.1941:={0}))",
                    dn);
                using (var groupSearch = new DirectorySearcher(root, filter, new[] { "sAMAccountName" }))
                {
                    groupSearch.PageSize = 1000;
                    using (var resultCollection = groupSearch.FindAll())
                    {
                        foreach (SearchResult result in resultCollection)
                        {
                            groups.Add((string) result.Properties["sAMAccountName"][0]);
                        }
                    }
                }
            }
        }
    }
