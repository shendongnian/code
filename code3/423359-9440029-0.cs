        private List<DirectoryUser> GetUsersInGroup(string groupName)
        {
            List<DirectoryUser> directoryUsers = new List<DirectoryUser>();
            try
            {
                ResultPropertyValueCollection members = null;
                using (var entry = new DirectoryEntry(_server))
                {
                    entry.Path = "LDAP://" + _usersRoot;
                    entry.Username = _domain + @"\" + _serviceAccountUsername;
                    entry.Password = _serviceAccountPassword;
                    entry.AuthenticationType = AuthenticationTypes.Secure;
                    using (DirectorySearcher searcher = new DirectorySearcher(entry))
                    {
                        searcher.Filter = "(&(objectClass=group)(cn=" + groupName + "))";
                        searcher.PropertiesToLoad.Add("member");
                        SearchResult result = searcher.FindOne();
                        if (result == null)
                            return directoryUsers;
                        members = result.Properties["member"];
                    }
                }
                if (members == null || members.Count == 0)
                    return directoryUsers;
                foreach (var member in members)
                {
                    using (var entry = new DirectoryEntry(_server))
                    {
                        entry.Path = "LDAP://" + member;
                        entry.Username = _domain + @"\" + _serviceAccountUsername;
                        entry.Password = _serviceAccountPassword;
                        entry.AuthenticationType = AuthenticationTypes.Secure;
                        using (DirectorySearcher searcher = new DirectorySearcher(entry))
                        {
                            searcher.Filter = "(objectClass=user)";
                            searcher.SearchScope = SearchScope.Base;
                            searcher.PropertiesToLoad.Add("mail");
                            searcher.PropertiesToLoad.Add("givenName");
                            searcher.PropertiesToLoad.Add("sn");
                            searcher.PropertiesToLoad.Add("sAMAccountName");
                            searcher.PropertiesToLoad.Add("telephoneNumber");
                            SearchResult result = searcher.FindOne();
                            if (result == null)
                                continue;
                            var dirUser = new DirectoryUser();
                            dirUser.Username = Convert.ToString(result.Properties["sAMAccountName"][0]);
                            dirUser.FirstName = Convert.ToString(result.Properties["givenName"][0]);
                            dirUser.LastName = Convert.ToString(result.Properties["sn"][0]);
                            dirUser.Email = Convert.ToString(result.Properties["mail"][0]);
                            dirUser.Phone = Convert.ToString(result.Properties["telephoneNumber"][0]);
                            directoryUsers.Add(dirUser);
                        }
                    }
                }
            }
            catch { }
            return directoryUsers;
        }
