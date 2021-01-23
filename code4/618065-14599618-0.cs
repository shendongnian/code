        public static String Encrypt(this String unSecuredString)
        {
            if (String.IsNullOrEmpty(unSecuredString))
                return unSecuredString;
            var decryptedData = Encoding.UTF8.GetBytes(unSecuredString);
            var encryptedData = ProtectedData.Protect(decryptedData, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encryptedData);
        }
        public static String Decrypt(this String securedString)
        {
            if (String.IsNullOrEmpty(securedString))
                return securedString;
            var encryptedData = Convert.FromBase64String(securedString);
            var decryptedData = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(decryptedData);
        }
