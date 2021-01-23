        public UserPass GetCredentials()
        {
            var cm = new Credential {Target = CredentialName};
            if (!cm.Exists())
                return null;
            cm.Load();
            var up = new UserPass(cm);
            return up;
        }
        public bool SetCredentials(UserPass up)
        {
            var cm = new Credential {Target = CredentialName, PersistanceType =  PersistanceType.Enterprise, Username = up.UserName, Password = up.Password};
            return cm.Save();
        }
        public void RemoveCredentials()
        {
            var cm = new Credential { Target = CredentialName };
            cm.Delete();
        }
