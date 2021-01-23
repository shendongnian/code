    bool isAdmin = false;
            RegisterInput model = new RegisterInput();
            NewUserInput usr = new NewUserInput();
            SearchResultCollection results;
            string mobileNumber = string.Empty;
            using (DirectoryEntry domainEntry = new DirectoryEntry("LDAP://" + AppSettings.DomainName))
            {
                using (DirectorySearcher searcher = new DirectorySearcher(domainEntry, "userPrincipalName=" + userName + "@" + AppSettings.DomainName) { Filter = string.Format("(&(objectClass=user)(samaccountname={0}))", userName) })
                {
                   results = searcher.FindAll();
                    if (results.Count > 0)
                    {
                        usr.FirstName = results[0].GetDirectoryEntry().Properties["givenName"].Value.ToString();
                        usr.LastName = results[0].GetDirectoryEntry().Properties["sn"].Value?.ToString();
                        usr.EmailAddress = results[0].GetDirectoryEntry().Properties["mail"].Value?.ToString();
                        mobileNumber = results[0].GetDirectoryEntry().Properties["mobile"]?.Value?.ToString();
                        dynamic userRoleList = results[0].GetDirectoryEntry().Properties["memberOf"];
                        if (userRoleList != null)
                        {
                            foreach (var role in userRoleList)
                            {
                                string[] split = role.ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                bool result = split.Any(x => x.ToLowerInvariant() == AppSettings.UserRole.ToLowerInvariant());
                                if (result)
                                {
                                    isAdmin = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            model.NewUser = usr;
