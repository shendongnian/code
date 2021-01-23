    public static string Decrypt(string cipherText)
    {
       string decryptedMessage = null;
       AesCryptoServiceProvider Aes = null;
       ICryptoTransform cTransform = null;
       try
       {
          //Decrypt:
          byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
          byte[] toDecryptArray = Convert.FromBase64String(cipherText);
          AesCryptoServiceProvider Aes = new AesCryptoServiceProvider();
          Aes.Key = keyArray;
          Aes.Mode = CipherMode.CBC;
          Aes.Padding = PaddingMode.PKCS7;
          Aes.IV = IV;
          ICryptoTransform cTransform = Aes.CreateDecryptor();
          byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
          decryptedMessage = UTF8Encoding.UTF8.GetString(resultArray, 0, resultArray.Length);
       }
       catch (Exception ex)
       {
          decryptedMessage = "FAILED:*" + cipherText + "*" + ex.Message;
       }
       finally
       {
           if (cTransform != null)
           {
               cTransForm.Dispose();
           }
           if (Aes != null)
           {
               Aes.Clear();
               Aes.Dispose();
           }
       }
       return decryptedMessage;
    }
