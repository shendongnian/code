      string groupName = "Domain Users";
                string domainName = "domain";
                var results = new List<string>();
                using (var pc = new PrincipalContext(ContextType.Domain, domainName))
                {
                    using (var grp = GroupPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, groupName))
                    {
                        if (grp != null)
                            foreach (var p in grp.GetMembers(false))
                            {
                                results.Add(p.DisplayName);
                            }
                    }
                    Assert.IsTrue(results.Count > 0);
                }
