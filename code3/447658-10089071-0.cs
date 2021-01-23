    class SecureStringManager
    {
        readonly Encoding _encoding = Encoding.Unicode;
        public string Unprotect(string encryptedString)
        {
            byte[] protectedData = Convert.FromBase64String(encryptedString);
            byte[] unprotectedData = ProtectedData.Unprotect(protectedData,
                null, DataProtectionScope.CurrentUser);
            return _encoding.GetString(unprotectedData);
        }
        public string Protect(string unprotectedString)
        {
            byte[] unprotectedData = _encoding.GetBytes(unprotectedString);
            byte[] protectedData = ProtectedData.Protect(unprotectedData, 
                null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(protectedData);
        }
    }      
     
