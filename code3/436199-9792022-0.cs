     public class UsernameDecryptor
     {
          public string Decrypt(string cipherText)
          {
               if (string.IsNullOrEmpty(cipherText))
                    return cipherText;
        
               byte[] salt = new byte[]
               {
                    (byte)0xc7,
                    (byte)0x73,
                     (byte)0x21,
                    (byte)0x8c,
                    (byte)0x7e,
                    (byte)0xc8,
                    (byte)0xee,
                    (byte)0x99
                };
                PKCSKeyGenerator crypto = new PKCSKeyGenerator("PASSWORD HERE", salt, 20, 1);
                ICryptoTransform cryptoTransform = crypto.Decryptor;
                byte[] cipherBytes = System.Convert.FromBase64String(cipherText);
                byte[] clearBytes = cryptoTransform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                
                return Encoding.UTF8.GetString(clearBytes);
          }
     }
