        public static List<string> ListOu()
        {
            List<string> ous = new List<string>();
            using (DirectoryEntry root = new DirectoryEntry("LDAP://dc=DOMAIN,dc=COM"))
            {
                DirectorySearcher searcher = new DirectorySearcher(root);
                searcher.Filter = "(&(objectClass=organizationalUnit))";
                searcher.SearchScope = SearchScope.Subtree;
                searcher.PropertiesToLoad.Add("distinguishedName");
                var result = searcher.FindAll();
                foreach (SearchResult entry in result)
                {
                    ous.Add(entry.GetDirectoryEntry().Properties["distinguishedName"].Value.ToString());
                }        
        
                result.Dispose();
                searcher.Dispose();
            }
            return ous;
        }
