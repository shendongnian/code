    string fullName = string.Empty;
                string givenName = string.Empty;
                string distinguishedName = string.Empty;
                string sAMAccountName = string.Empty;
                using (var context = new PrincipalContext(ContextType.Domain, "DOMAIN"))
                {
                    using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                    {
                        foreach (Principal result in searcher.FindAll())
                        {
                            var de = result.GetUnderlyingObject() as DirectoryEntry;
    
                            if (de.Properties["cn"].Value.ToString().Contains(" "))
                            {
    
                                //var userEntry = new DirectoryUser(de.Properties["sAMAccountName"].Value.ToString());
                                var currentUserEmail = de.Properties["mail"].Value.ToString().ToLower();
                                if (currentUserEmail == emailAddress)
                                {
                                    
                                    if (de.Properties["cn"].Value != null)
                                        fullName = de.Properties["cn"].Value.ToString();
                                    if (de.Properties["givenName"].Value != null)
                                       givenName = de.Properties["givenName"].Value.ToString();
                                    if (de.Properties["distinguishedName"].Value != null)
                                        distinguishedName =de.Properties["distinguishedName"].Value.ToString();
                                    if (de.Properties["sAMAccountName"].Value != null)
                                        sAMAccountName = de.Properties["sAMAccountName"].Value.ToString();
                                    
    
                                }
                            }
                        }
                    }
                }
