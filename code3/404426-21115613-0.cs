            public static string GetProperty(string adUserId, string domain, string lDAPLoginId, string lDAPPassword, string propertyName)
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain, lDAPLoginId, lDAPPassword);
                UserPrincipal up = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, adUserId);
    
                string result = "";
    
                if (up != null)
                {
                    result = PrincipalGetProperty(up, propertyName);
                }
    
                return result;
            }
