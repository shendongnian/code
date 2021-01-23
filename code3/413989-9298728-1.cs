    public class TntCryptoUtils
    {
        private static ICryptoTransform __Get_AES128_Transform(string password, bool AsDecryptor)
        {
            const int KEY_SIZE = 16;
            var sha256CryptoServiceProvider = new SHA256CryptoServiceProvider();
            var hash = sha256CryptoServiceProvider.ComputeHash(Encoding.Unicode.GetBytes(password));
            var key = new byte[KEY_SIZE];
            var iv = new byte[KEY_SIZE];
            Buffer.BlockCopy(hash, 0, key, 0, KEY_SIZE);
            //Buffer.BlockCopy(hash, KEY_SIZE, iv, 0, KEY_SIZE); // On the Windows side, the IV is always 0 (zero)
            //
            if (AsDecryptor)
                return new AesCryptoServiceProvider().CreateDecryptor(key, iv);
            else
                return new AesCryptoServiceProvider().CreateEncryptor(key, iv);
        }
    
        public static string AES128_Encrypt(string Value, string Password)
        {
            byte[] Buffer = Encoding.Unicode.GetBytes(Value);
            //
            using (ICryptoTransform transform = __Get_AES128_Transform(Password, false))
            {
                byte[] encyptedBlob = transform.TransformFinalBlock(Buffer, 0, Buffer.Length);
                return Convert.ToBase64String(encyptedBlob);
            }
        }
    
        public static string AES128_Decrypt(string Value, string Password)
        {
            byte[] Buffer = Convert.FromBase64String(Value);
            //
            using (ICryptoTransform transform = __Get_AES128_Transform(Password, true))
            {
                byte[] decyptedBlob = transform.TransformFinalBlock(Buffer, 0, Buffer.Length);
                return Encoding.Unicode.GetString(decyptedBlob);
            }
        }
    }
