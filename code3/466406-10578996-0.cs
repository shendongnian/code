    using System.DirectoryServices;
    using System.DirectoryServices.ActiveDirectory;
            using (var domain = Domain.GetCurrentDomain())
            using (var directoryEntry = domain.GetDirectoryEntry())
            using (var directorySearcher = new DirectorySearcher(directoryEntry, "(&(objectCategory=person)(objectClass=user))"))
            {
                directorySearcher.PageSize = 1000;
                using (var searchResults = directorySearcher.FindAll())
                {
                    foreach (SearchResult searchResult in searchResults)
                    {
                        using (var userEntry = searchResult.GetDirectoryEntry())
                        {
                            Console.WriteLine(userEntry.Properties["cn"][0]);
                        }
                    }
                }
            }
