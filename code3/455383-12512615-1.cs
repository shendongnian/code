            using (DirectoryEntry directoryEntry = new DirectoryEntry(DirectoryConstants.RootDSE))
            {
                // Create a Global Catalog Directory Service Searcher
                string strRootName = directoryEntry.Properties[DirectoryConstants.RootDomainNamingContext].Value.ToString();
                using (DirectoryEntry usersBinding = new DirectoryEntry(DirectoryConstants.GlobalCatalogProtocol + strRootName))
                {
                    directorySearcher.SearchRoot = usersBinding;
                    directorySearcher.ClientTimeout = timeout;
                    directorySearcher.CacheResults = true;
                    result = true;
                    initialized = true;
                }
            }
