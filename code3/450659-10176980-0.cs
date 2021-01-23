    public class DataEncryptor
    {
        TripleDESCryptoServiceProvider symm;
        #region Factory
        public DataEncryptor()
        {
            this.symm = new TripleDESCryptoServiceProvider();
            this.symm.Padding = PaddingMode.PKCS7;
        }
        public DataEncryptor(TripleDESCryptoServiceProvider keys)
        {
            this.symm = keys;
        }
        public DataEncryptor(byte[] key, byte[] iv)
        {
            this.symm = new TripleDESCryptoServiceProvider();
            this.symm.Padding = PaddingMode.PKCS7;
            this.symm.Key = key;
            this.symm.IV = iv;
        }
        #endregion
        #region Properties
        public TripleDESCryptoServiceProvider Algorithm
        {
            get { return symm; }
            set { symm = value; }
        }
        public byte[] Key
        {
            get { return symm.Key; }
            set { symm.Key = value; }
        }
        public byte[] IV
        {
            get { return symm.IV; }
            set { symm.IV = value; }
        }
        #endregion
        #region Crypto
        public byte[] Encrypt(byte[] data) { return Encrypt(data, data.Length); }
        public byte[] Encrypt(byte[] data, int length)
        {
            try
            {
                // Create a MemoryStream.
                var ms = new MemoryStream();
                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                var cs = new CryptoStream(ms,
                    symm.CreateEncryptor(symm.Key, symm.IV),
                    CryptoStreamMode.Write);
                // Write the byte array to the crypto stream and flush it.
                cs.Write(data, 0, length);
                cs.FlushFinalBlock();
                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = ms.ToArray();
                // Close the streams.
                cs.Close();
                ms.Close();
                // Return the encrypted buffer.
                return ret;
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("A cryptographic error occured: {0}", ex.Message);
            }
            return null;
        }
        public string EncryptString(string text)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(text)));
        }
        public byte[] Decrypt(byte[] data) { return Decrypt(data, data.Length); }
        public byte[] Decrypt(byte[] data, int length)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream ms = new MemoryStream(data);
                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cs = new CryptoStream(ms,
                    symm.CreateDecryptor(symm.Key, symm.IV),
                    CryptoStreamMode.Read);
                // Create buffer to hold the decrypted data.
                byte[] result = new byte[length];
                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                cs.Read(result, 0, result.Length);
                return result;
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine("A cryptographic error occured: {0}", ex.Message);
            }
            return null;
        }
        public string DecryptString(string data)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(data))).TrimEnd('\0');
        }
        #endregion
    }
