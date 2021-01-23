    public class EncryptingFileStream : System.IO.StreamReader
    {
        public EncryptingFileStream(string fileName, byte[] key, byte[] IV)
            : base(GenerateCryptoStream(fileName, key, IV))
        {
        }
        private static System.IO.Stream GenerateCryptoStream(string fileName, byte[] key, byte[] IV)
        {
            using (System.Security.Cryptography.Rijndael rijAlg = System.Security.Cryptography.Rijndael.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = IV;
                // Create a decrytor to perform the stream transform.
                using (System.IO.FileStream fs = System.IO.File.Open(fileName, System.IO.FileMode.Open))
                {
                    return new System.Security.Cryptography.CryptoStream(fs, rijAlg.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Read);
                }
            }
        }
    }
