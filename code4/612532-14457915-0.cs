    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    
    using Synercoding.CodeGuard;
    
    namespace Synercoding.Encryption.Symmetrical
    {
        /// <summary>
        /// A class to Encrypt and Decrypt with Rijndael AES encryption
        /// </summary>
        public sealed class AesEncryption : IDisposable
        {
            private byte[] m_salt;
            private RijndaelManaged m_aesAlg = new RijndaelManaged(); // RijndaelManaged object used to encrypt/decrypt the data.
    
            /// <summary>
            /// Create a new AesEncryption object with the standard salt
            /// </summary>
            public AesEncryption() : this("850nW94vN39iUx") { }
    
            /// <summary>
            /// Create a new AesEncryption object with the specified salt
            /// </summary>
            /// <param name="salt">The salt used for salting the key. Must be atleast 8 chars long</param>
            public AesEncryption(string salt)
            {
                Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(salt), "param salt can't be null or empty.");
                Guard.Requires<ArgumentException>(salt.Length >= 8, "param salt must be atleast 8 chars long.");
                m_salt = Encoding.ASCII.GetBytes(salt);
            }
    
            /// <summary>
            /// The salt in ASCII string format
            /// </summary>
            public string SaltString
            {
                get
                {
                    return Encoding.ASCII.GetString(m_salt);
                }
            }
    
            /// <summary>
            /// The salt that is used for the key and IV generation.
            /// </summary>
            public byte[] Salt
            {
                get
                {
                    return m_salt;
                }
            }
    
            /// <summary>
            /// Encrypt the given string using AES.  The string can be decrypted using 
            /// DecryptStringAES().  The sharedSecret parameters must match.
            /// </summary>
            /// <param name="plainText">The text to encrypt.</param>
            /// <param name="sharedSecret">A password used to generate a key for encryption.</param>
            public string EncryptStringAES(string plainText, string sharedSecret)
            {
                Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(plainText), "param plainText can't be null or empty");
                Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(sharedSecret), "param sharedSecret can't be null or empty");
                Guard.Requires<InvalidOperationException>(m_aesAlg != null, "this object is already disposed");
    
                string outStr = null;                       // Encrypted string to return
    
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, Salt);
    
                m_aesAlg.Key = key.GetBytes(m_aesAlg.KeySize / 8);
                m_aesAlg.IV = key.GetBytes(m_aesAlg.BlockSize / 8);
    
    
                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = m_aesAlg.CreateEncryptor(m_aesAlg.Key, m_aesAlg.IV);
    
                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
    
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
    
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
    
                // Return the encrypted bytes from the memory stream.
                return outStr;
            }
    
            /// <summary>
            /// Decrypt the given string.  Assumes the string was encrypted using 
            /// EncryptStringAES(), using an identical sharedSecret.
            /// </summary>
            /// <param name="cipherText">The text to decrypt.</param>
            /// <param name="sharedSecret">A password used to generate a key for decryption.</param>
            public string DecryptStringAES(string cipherText, string sharedSecret)
            {
                Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(cipherText), "param cipherText can't be null or empty");
                Guard.Requires<ArgumentNullException>(!string.IsNullOrEmpty(sharedSecret), "param sharedSecret can't be null or empty");
                Guard.Requires<InvalidOperationException>(m_aesAlg != null, "this object is already disposed");
    
                // Declare the string used to hold
                // the decrypted text.
                string plaintext = null;
    
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, Salt);
    
                m_aesAlg.Key = key.GetBytes(m_aesAlg.KeySize / 8);
                m_aesAlg.IV = key.GetBytes(m_aesAlg.BlockSize / 8);
    
                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = m_aesAlg.CreateDecryptor(m_aesAlg.Key, m_aesAlg.IV);
                // Create the streams used for decryption.                
                byte[] bytes = Convert.FromBase64String(cipherText);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
    
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
    
                return plaintext;
            }
    
            public void Dispose()
            {
                if (m_aesAlg != null)
                {
                    m_aesAlg.Clear();
                    m_aesAlg.Dispose();
                    m_aesAlg = null;
                }
            }
        }
    }
