    private string[] GetUserRoles(string Username)
    {    
        List<string> roles = new List<string>();
        try
        {
            string domain = Username.Contains("\\") ? Username.Substring(0, Username.IndexOf("\\")) : string.Empty;
            string username = Username.Contains("\\") ? Username.Substring(Username.LastIndexOf("\\") + 1) : Username;
            if (!string.IsNullOrEmpty(domain) && !string.IsNullOrEmpty(username))
            {
                PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain);
                UserPrincipal user = UserPrincipal.FindByIdentity(principalContext, username);
                if (user != null)
                {
                    PrincipalSearchResult<Principal> groups = user.GetAuthorizationGroups();
                    int count = groups.Count();
                    for (int i = 0; i < count; i++)
                    {
                        IEnumerable<Principal> principalCollection = groups.Skip(i).Take(1);
                        Principal principal = null;
                        try
                        {
                            principal = principalCollection.FirstOrDefault();
                        }
                        catch (Exception e)
                        {
                            //Error handling...
                            //Known exception - sometimes AD can't query a particular group, requires server hotfix?
                            //http://support.microsoft.com/kb/2830145
                        }
                        
                        if (principal!=null && principal is GroupPrincipal)
                        {
                            GroupPrincipal groupPrincipal = (GroupPrincipal)principal;
                            if (groupPrincipal != null && !string.IsNullOrEmpty(groupPrincipal.Name))
                            {
                                roles.Add(groupPrincipal.Name.Trim());
                            }
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            //Error handling...
        }
        return roles.ToArray();
    }
