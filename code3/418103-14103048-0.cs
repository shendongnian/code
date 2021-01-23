    public bool  ValidateUser(string varDomain, string varUserName, string varPwd)
        {
            Boolean isValidUser;
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, varDomain))
            {
                isValidUser = pc.ValidateCredentials(varUserName, varPwd);
            }
            return isValidUser;
 
        }
