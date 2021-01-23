    private static bool UserIsMember(string usr, string grp)
    {
        usr = usr.ToLower();
        grp = grp.ToLower();
        
        using (var pc = new PrincipalContext(ContextType.Domain, "DOMAIN_NAME"))
        {
            using (var user = UserPrincipal.FindByIdentity(pc, usr))
            {
                var isMember = false;
                var authGroups = user?.GetAuthorizationGroups().GetEnumerator();
                while (authGroups?.MoveNext() ?? false)
                {
                    try
                    {
                        isMember = authGroups.Current.Name.ToLower().Contains(grp);
                        if (isMember) break;
                    }
                    catch
                    {
                        // ignored
                    }
                }
                authGroups?.Dispose();
                return isMember;
            }
        }
    }
