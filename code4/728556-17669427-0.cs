    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Security.Cryptography;
    using System.IO;
    
    
    namespace Encryption_test_app
    {
        class Program
        {
            static void Main(string[] args)
            {
                var encoding = new UTF8Encoding(false, true);
                var cryptor = new RijndaelEncryptor();
    
                var plainText = "Hello World!";
                Debug.Print("Plain Text: [{0}]", plainText);
    
                byte[] cypherBytes = cryptor.Encrypt(encoding.GetBytes(plainText));
                string decryptedText = encoding.GetString(cryptor.Decrypt(cypherBytes));
                
                Debug.Print("Decrypted Text: [{0}]", decryptedText);
                Debug.Print("PlainText == Decrypted Text: [{0}]", plainText == decryptedText);
            }
        }
    
    
    
        /// <summary>
        /// Simple class to encrypt/decrypt a byte array using the <see cref="RijndaelManaged"/> cryptographic algorithm.
        /// </summary>
        public class RijndaelEncryptor : IDisposable
        {
    
            private RijndaelManaged _crypt = new RijndaelManaged();
            
            #region Constructors
    
            /// <summary>
            /// Initializes a new instance of the <see cref="RijndaelEncryptor"/> class using a default key and initial vector (IV).
            /// </summary>
            public RijndaelEncryptor() : this("0nce @pon a time...", "There lived a princess who 1iked frogs...") { }
    
            /// <summary>
            /// Initializes a new instance of the <see cref="RijndaelEncryptor"/> class using the plain text key and initial vector
            /// which are used to construct encrypted key and IV values using the maximum allowed key and iv sizes for 
            /// the <see cref="RijndaelEncryptor"/> cryptographic algorithm.
            /// </summary>
            /// <param name="keyPassword"></param>
            /// <param name="ivPassword"></param>
            public RijndaelEncryptor(string keyPassword, string ivPassword) 
            {
                if (string.IsNullOrEmpty(keyPassword)) throw new ArgumentOutOfRangeException("keyPassword", "Cannot be null or empty");
                if (string.IsNullOrEmpty(ivPassword)) throw new ArgumentOutOfRangeException("ivPassword", "Cannot be null or empty");
    
                KeyPassword = keyPassword;
                IVPassword = ivPassword;
    
                _crypt.KeySize = _crypt.LegalKeySizes[0].MaxSize;
    
                EncryptKey = _stringToBytes(KeyPassword, _crypt.KeySize >> 3);
                EncryptIV = _stringToBytes(IVPassword, _crypt.BlockSize >> 3);
    
            }
    
            /// <summary>
            /// Initializes a new instance of the <see cref="RijndaelEncryptor"/> class using the user supplied key and initial vector arrays.
            /// NOTE: these arrays will be validated for use with the <see cref="RijndaelManaged"/> cypher.
            /// </summary>
            /// <param name="encryptedKey"></param>
            /// <param name="encryptedIV"></param>
            public RijndaelEncryptor(byte[] encryptedKey, byte[] encryptedIV)
            {
                if (encryptedKey == null) throw new ArgumentNullException("encryptedKey");
                if (encryptedIV == null) throw new ArgumentNullException("encryptedIV");
    
                //Verify encrypted key length is valid for this cryptor algo.
                int keylen = encryptedKey.Length << 3;
                if (!_crypt.ValidKeySize(keylen))
                {
                    string errmsg = "Encryption key length(" + keylen.ToString() + ") is not for this algorithm:" + _crypt.GetType().Name;
                    throw new ApplicationException(errmsg);
                }
    
                //Verify encrypted iv length is valid for this cryptor algo.
                int len = encryptedIV.Length << 3;
                if (len != _crypt.BlockSize)
                {
                    string errmsg = "Encryption key length(" + len.ToString() + ") is not for this algorithm:" + _crypt.GetType().Name;
                    throw new ApplicationException(errmsg);
                }
    
                EncryptKey = encryptedKey;
                EncryptIV = encryptedIV;
            }
    
            #endregion
    
            /// <summary>
            /// Plain text encryption key. Is used to generate a encrypted key <see cref="EncryptKey"/>
            /// </summary>
            public string KeyPassword { get; private set; }
    
            /// <summary>
            /// Plain text encryption initial vector. Is used to generate a encrypted IV <see cref="EncryptIV"/>
            /// </summary>
            public string IVPassword { get; private set; }
    
            /// <summary>
            /// Encrypted encryption key. (Size must match one of the allowed sizes for this encryption method).
            /// </summary>
            public byte[] EncryptKey { get; private set; }
    
            /// <summary>
            /// Encrypted encryption IV. (Size must match one of the allowed sizes for this encryption method).
            /// </summary>
            public byte[] EncryptIV { get; private set; }
    
    
            /// <summary>
            /// Encrypts the given byte array using the defined <see cref="EncryptKey"/> and <see cref="EncryptIV"/> values.
            /// </summary>
            /// <param name="plaintext"></param>
            /// <returns></returns>
            public byte[] Encrypt(byte[] plaintext)
            {
                return(_encrypt(plaintext, EncryptKey, EncryptIV));
            }
    
            /// <summary>
            /// Decrypts the given byte array using the defined <see cref="EncryptKey"/> and <see cref="EncryptIV"/> values.
            /// </summary>
            /// <param name="cypherBytes"></param>
            /// <returns></returns>
            public byte[] Decrypt(byte[] cypherBytes)
            {
                return (_decrypt(cypherBytes, EncryptKey, EncryptIV));
            }
    
    
            #region Private Encryption methods
    
    
            /// <summary>
            /// Used to encrypt the plain-text key and iv values to not so easy to ready byte arrays of the given size.
            /// </summary>
            /// <param name="password"></param>
            /// <param name="KeyByteSize"></param>
            /// <returns></returns>
            private byte[] _stringToBytes(string password, int KeyByteSize)
            {
                byte[] salt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0xfe, 0x00, 0xa7, 0xd3, 0x02, 0x02, 0x97, 0xc4, 0xa5, 0x32 };
                PasswordDeriveBytes b = new PasswordDeriveBytes(password, salt);
                return (b.GetBytes(KeyByteSize));
            }
    
            /// <summary>
            /// Encrypts the <paramref name="plainBytes"/> array using the given key and initial vector.
            /// </summary>
            /// <remarks>
            /// This routine embeds the length of the plain data at the beginning of the encrypted record. This would be 
            /// frowed apon by crypto experts. However, if you dont do this you may get extraneous data (extra null bytes)
            /// at the end of the decrypted byte array. This embedded length is used to trim the final decrypted array to size.
            /// </remarks>
            /// <param name="plainBytes"></param>
            /// <param name="key"></param>
            /// <param name="iv"></param>
            /// <returns></returns>
            private byte[] _encrypt(byte[] plainBytes, byte[] key, byte[] iv)
            {
                try
                {
                    // Create a MemoryStream.
                    using (MemoryStream mStream = new MemoryStream())
                    {
                        // Create a CryptoStream using the MemoryStream 
                        // and the passed key and initialization vector (IV).
                        using (CryptoStream cStream = new CryptoStream(mStream, _crypt.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                        {
    
                            // Write the byte array to the crypto stream and flush it.
                            byte[] recordLen = BitConverter.GetBytes(plainBytes.Length);
                            cStream.Write(recordLen, 0, recordLen.Length);
                            cStream.Write(plainBytes, 0, plainBytes.Length);
    
                            if (!cStream.HasFlushedFinalBlock)
                            {
                                cStream.FlushFinalBlock();
                            }
    
                            // Get an array of bytes from the 
                            // MemoryStream that holds the 
                            // encrypted data.
                            return(mStream.ToArray());
    
                        }
                    }
                }
                catch (CryptographicException ex)
                {
                    throw new ApplicationException("**ERROR** occurred during Encryption", ex);
                }
    
            }
    
            /// <summary>
            /// Decrypts the <paramref name="cryptBytes"/> array using the given key and initial vector.
            /// </summary>
            /// <param name="plainBytes"></param>
            /// <param name="key"></param>
            /// <param name="iv"></param>
            /// <returns></returns>
            private byte[] _decrypt(byte[] cryptBytes, byte[] key, byte[] iv)
            {
                try
                {
                    // Create a new MemoryStream using the passed 
                    // array of encrypted data.
                    using (MemoryStream msDecrypt = new MemoryStream(cryptBytes))
                    {
                        // Create a CryptoStream using the MemoryStream 
                        // and the passed key and initialization vector (IV).
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, _crypt.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                        {
                            byte[] recordLen = BitConverter.GetBytes((int)0);
                            csDecrypt.Read(recordLen, 0, recordLen.Length);
                            int length = BitConverter.ToInt32(recordLen, 0);
    
                            // Create buffer to hold the decrypted data.
                            byte[] fromEncrypt = new byte[cryptBytes.Length - recordLen.Length];
    
                            // Read the decrypted data out of the crypto stream
                            // and place it into the temporary buffer.
                            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
    
                            byte[] plainBytes = new byte[length];
                            Array.Copy(fromEncrypt, plainBytes, length);
    
                            return (plainBytes);
                        }
                    }
                }
                catch (CryptographicException ex)
                {
                    throw new ApplicationException("**ERROR** occurred during Decryption", ex);
                }
            }
    
            #endregion
    
            #region IDisposable Members
    
            private bool disposed = false;	//indicates if this instance has been disposed.
    
            private void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    //Dispose managed objects
                    if (disposing)
                    {
                        if (_crypt != null)
                        {
                            try { _crypt.Clear(); }
                            finally { _crypt = null; }
                        }
                    }
    
                    //Dispose Unmanaged objects
                }
                this.disposed = true;
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            ~RijndaelEncryptor() { Dispose(false); }
    
            #endregion
    
    
        }
    
    }
