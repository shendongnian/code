        static public bool CheckCredentials(
            string userName, string password, string domain)
        {
            string userPrincipalName = userName + "@" + domain + ".com";
            try
            {
                using (var context = new PrincipalContext(ContextType.Domain, domain))
                {
                    return context.ValidateCredentials(userPrincipalName, password);
                }
            }
            catch // a bogus domain causes an LDAP error
            {
                return false;
            }
        }
