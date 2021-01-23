    public class EncryptionHelper
    {        
        static SymmetricAlgorithm encryption; 
        static string password = "password";
        static string salt = "this is my salt. There are many like it, but this one is mine.";
        static EncryptionHelper()
        {
            encryption = new RijndaelManaged();
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(salt));
            encryption.Key = key.GetBytes(encryption.KeySize / 8);
            encryption.IV = key.GetBytes(encryption.BlockSize / 8);
            encryption.Padding = PaddingMode.PKCS7;
        }
        public void Encrypt(Stream inStream, Stream OutStream)
        {
            ICryptoTransform encryptor = encryption.CreateEncryptor();
            inStream.Position = 0;
            CryptoStream encryptStream = new CryptoStream(OutStream, encryptor, CryptoStreamMode.Write);
            inStream.CopyTo(encryptStream);
            encryptStream.FlushFinalBlock();
        }
        public void Decrypt(Stream inStream, Stream OutStream)
        {
            ICryptoTransform encryptor = encryption.CreateDecryptor();
            inStream.Position = 0;
            CryptoStream encryptStream = new CryptoStream(inStream, encryptor, CryptoStreamMode.Read);
            
            encryptStream.CopyTo(OutStream);
            OutStream.Position = 0;
            
        }
    
    }
