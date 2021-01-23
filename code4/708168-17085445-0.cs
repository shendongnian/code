        public bool ValidateUser(string userName, string password)
        {
            bool authenticated = false;
            string dePath = string.Empty;
            dePath += DomainController;
            if (!string.IsNullOrEmpty(BaseDomainName))
            {
                dePath += "/" + BaseDomainName; 
            }
            try
            {
                DirectoryEntry entry = new DirectoryEntry(dePath, userName, password);
                object nativeObject = entry.NativeObject;
                authenticated = true;
            }
            catch
            {
                return false;
            }
            return authenticated;
        }
