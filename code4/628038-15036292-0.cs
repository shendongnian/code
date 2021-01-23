                   List<SearchResult> searchResults;
    
                    // use login account to access active directory (otherwise it will use the IIS user account, which does not have permissions)
                    using (DirectoryEntry root = new DirectoryEntry("LDAP://CN=Users,DC=test,DC=example,DC=com", "usernameCredential", "passwordCredential"))
                    using (DirectorySearcher searcher = new DirectorySearcher(root, "(&amp;(objectCategory=person)(objectClass=user))"))
                    using (SearchResultCollection results = searcher.FindAll())
                    {
                        searchResults = results.Cast<SearchResult>().ToList();
                    }
    
                    // get the active directory users name and username
                    return searchResults
                        .Select(u => new ActiveDirectoryUser()
                        {
                            NetworkId = String.Format(@"{0}\{1}", this._domainName, u.Properties["sAMAccountName"][0]),
                            FullName = (string) u.Properties["cn"][0]
                        }).AsQueryable();
