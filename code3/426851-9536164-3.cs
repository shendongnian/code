        public static string Decrypt(string cipherText)
        {
           AesCryptoServiceProvider Aes;
           try
           {
              //Decrypt:
              byte[] keyArray;
              byte[] toDecryptArray = Convert.FromBase64String(cipherText);
              keyArray = UTF8Encoding.UTF8.GetBytes(key);
              Aes = new AesCryptoServiceProvider();
              Aes.Key = keyArray;
              Aes.Mode = CipherMode.CBC;
              Aes.Padding = PaddingMode.PKCS7;
              Aes.IV = IV;
              using (ICryptoTransform cTransform = Aes.CreateDecryptor())
              {
                byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
                Aes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray, 0, resultArray.Length);
              }
           }
           catch (Exception ex)
           {
              return "FAILED:*" + cipherText + "*" + ex.Message;
           }
           finally
           {
              Aes.Dispose();
           }
        }
