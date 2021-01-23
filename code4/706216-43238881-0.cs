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
                        var g = authGroups.Current.Name.ToLower();
                        if (!g.Contains(grp)) continue;
                        isMember = true;
                        break;
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
