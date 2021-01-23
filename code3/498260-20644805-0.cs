    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
     
    namespace MVC3JavaScript_3_2012.Utilities
    {
        public class MyTripleDES
        {
     private readonly TripleDESCryptoServiceProvider _des = new TripleDESCryptoServiceProvider();
            private readonly UTF8Encoding _utf8 = new UTF8Encoding();
     
            /// <summary>
            /// Key to use during encryption and decryption
            /// </summary>
            private byte[] _keyValue;
            public byte[] Key
            {
                get { return _keyValue; }
                private set { _keyValue = value; }
            }
     
            /// <summary>
            /// Initialization vector to use during encryption and decryption
            /// </summary>
            private byte[] _ivValue;
            public byte[] IV
            {
                get { return _ivValue; }
                private set { _ivValue = value; }
            }
     
            /// <summary>
            /// Constructor, allows the key and initialization vector to be provided as strings
            /// </summary>
            /// <param name="key"></param>
            /// <param name="iv"></param>
            public MyTripleDES(string key, string iv)
            {
                _keyValue = Convert.FromBase64String(key);
                _ivValue = Convert.FromBase64String(iv);
            }
     
            /// <summary>
            /// Decrypt Bytes
            /// </summary>
            /// <param name="bytes"></param>
            /// <returns></returns>
            public byte[] Decrypt(byte[] bytes)
            {
                return Transform(bytes, _des.CreateDecryptor(_keyValue, _ivValue));
            }
     
            /// <summary>
            /// Encrypt Bytes
            /// </summary>
            /// <param name="bytes"></param>
            /// <returns></returns>
            public byte[] Encrypt(byte[] bytes)
            {
                return Transform(bytes, _des.CreateEncryptor(_keyValue, _ivValue));
            }
     
            /// <summary>
            /// Decrypt a string
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public string Decrypt(string text)
            {
                byte[] input = HttpServerUtility.UrlTokenDecode(text);
                byte[] output = Transform(input, _des.CreateDecryptor(_keyValue, _ivValue));
                return _utf8.GetString(output);
            }
     
            /// <summary>
            /// Encrypt a string and return Base64String
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            public string Encrypt(string text)
            {
                byte[] input = _utf8.GetBytes(text);
                byte[] output = Transform(input, _des.CreateEncryptor(_keyValue, _ivValue));
                return HttpServerUtility.UrlTokenEncode(output);
            }
     
            /// <summary>
            /// Encrypt or Decrypt bytes.
            /// </summary>
            private byte[] Transform(byte[] input, ICryptoTransform cryptoTransform)
            {
                // Create the necessary streams
                using (var memory = new MemoryStream())
                {
                    using (var stream = new CryptoStream(memory, cryptoTransform, CryptoStreamMode.Write))
                    {
                        // Transform the bytes as requested
                        stream.Write(input, 0, input.Length);
                        stream.FlushFinalBlock();
     
                        // Read the memory stream and convert it back into byte array
                        memory.Position = 0;
                        var result = new byte[memory.Length];
                        memory.Read(result, 0, result.Length);
     
                        // Return result
                        return result;
                    }
                }
            }
     
            public static string CreateNewVector()
            {
                using (var des = new System.Security.Cryptography.TripleDESCryptoServiceProvider())
                {
                    des.GenerateIV();
                    return Convert.ToBase64String(des.IV);
                }
            }
     
            public static string CreateNewKey()
            {
                using (var des = new System.Security.Cryptography.TripleDESCryptoServiceProvider())
                {
                    des.GenerateKey();
                    return Convert.ToBase64String(des.Key);
                }
            }
        }
    }
   
