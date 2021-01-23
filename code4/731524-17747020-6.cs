    public static class CredentialUtil
    {
        public static UserPass GetCredential(string target)
        {
            var cm = new Credential {Target = target};
            if (!cm.Load())
            {
                return null;
            }
            
            //UserPass is just a class with two string properties for user and pass
            return new UserPass(cm.Username, cm.Password);
        }
        
        public static bool SetCredentials(
             string target, string username, string password, PersistanceType persistenceType)
        {
           return new Credential {Target = target, Username = username, 
                   Password = password, PersistanceType =  persistenceType}.Save();
        }
    
        public static bool RemoveCredentials(string target)
        {
            return new Credential { Target = target }.Delete();
        }
    }
