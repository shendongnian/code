    public Dictionary<string, string> GetOUInfo(SearchScope eSearchScope)
        {
            Dictionary<string, string> retValues = new Dictionary<string, string>();
            try
            {
                DirectoryEntry oDirectoryEntry = new DirectoryEntry("LDAP://myServer:1111/DC=myApp,DC=myDomain,DC=com", Username, Password);
                DirectorySearcher oDirectorySearcher = new DirectorySearcher(oDirectoryEntry,
                    "(objectCategory=organizationalUnit)", null, eSearchScope);
                SearchResultCollection oSearchResultCollection = oDirectorySearcher.FindAll();
                foreach (SearchResult item in oSearchResultCollection)
                {
                    string name = item.Properties["name"][0].ToString();
                    string path = item.GetDirectoryEntry().Path;
                    retValues.Add(path, name);
                }
            }
            catch (Exception ex)
            {
            }
            return retValues;
        }
