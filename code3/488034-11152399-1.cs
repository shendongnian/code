    public class Cryptographer
    {
        private const int keyByteLength = 20;
        public static void Encrypt(string password, 
                                   out byte[] salt,
                                   out byte[] key)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 
                                                            keyByteLength))
            {
                salt = deriveBytes.Salt;
                key = deriveBytes.GetBytes(keyByteLength);  
            }
        }
        public static bool IsValidPassword(string password, 
                                           byte[] salt, 
                                           byte[] key)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt))
            {
                byte[] newKey = deriveBytes.GetBytes(keyByteLength);  
                return newKey.SequenceEqual(key);
            }
        }
    }
