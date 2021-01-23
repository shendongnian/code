        public void WriteEntries(DirectoryEntry domainRoot)
        {
            DirectorySearcher searcher = new DirectorySearcher(domainRoot);
            searcher.PropertiesToLoad.Add("displayName");
            searcher.PropertiesToLoad.Add("cn");
            searcher.PropertiesToLoad.Add("department");
            searcher.Filter = "(&(objectCategory=person))";
            foreach (SearchResult result in searcher.FindAll())
            {
                // Login Name
                Console.WriteLine(GetProperty(result, "cn"));
                // Display Name
                Console.WriteLine(GetProperty(result, "displayName"));
                // Department
                Console.WriteLine(GetProperty(result, "department"));
            }
        }
        private string GetProperty(SearchResult searchResult, string PropertyName)
        {
            if (searchResult.Properties.Contains(PropertyName))
            {
                return searchResult.Properties[PropertyName][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }
