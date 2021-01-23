    public static class StringSecurityHelper
    {
        private static readonly byte[] entropy = Encoding.Unicode.GetBytes("5ID'&mc %sJo@lGtbi%n!G^ fiVn8 *tNh3eB %rDaVijn!.c b");
        public static string EncryptString(this string input)
        {
            if (input == null)
            {
                return null;
            }
            byte[] encryptedData = ProtectedData.Protect(Encoding.Unicode.GetBytes(input), entropy, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encryptedData);
        }
        public static string DecryptString(this string encryptedData)
        {
            if (encryptedData == null)
            {
                return null;
            }
            try
            {
                byte[] decryptedData = ProtectedData.Unprotect(Convert.FromBase64String(encryptedData), entropy, DataProtectionScope.CurrentUser);
                return Encoding.Unicode.GetString(decryptedData);
            }
            catch
            {
                return null;
            }
        }
    }
