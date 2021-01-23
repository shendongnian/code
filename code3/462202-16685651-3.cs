    var path = "GC://DC=main,DC=com";
    try
    {
        using (var root = new DirectoryEntry(path, username, password))
        {
            var searchFilter = string.Format("(&(anr={0})(objectCategory=user)(objectClass=user))", mask);
            using (var searcher = new DirectorySearcher(root, searchFilter, new[] { "objectSid", "userPrincipalName" }))
            {
                var results = searcher.FindAll();
                foreach (SearchResult item in results)
                {
                    //What ever you do
                }
            }
        }
    }
    catch (DirectoryServicesCOMException)
    {
        // username or password are wrong
    }
