    static string PHPDecrypt() 
    	{            
          byte[] keyBytes = Convert.FromBase64String("U6XksFkhWV4.......eo3fRg=="); //put in your real values here and below for iv and cipherTextBytes
          byte[] iv = Convert.FromBase64String("KLnP....wA=="");
          byte[] cipherTextBytes = Convert.FromBase64String("Put the EncryptedText here");
        
          var symmetricKey = new RijndaelManaged 
          { 
             Mode = CipherMode.CBC, 
             IV = iv, KeySize = 256, 
             Key = keyBytes, 
             Padding = PaddingMode.Zeros
          };
        
          using (var decryptor = symmetricKey.CreateDecryptor())
          using (var ms = new MemoryStream(cipherTextBytes))
          using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read)) {
            var plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cs.Read(plainTextBytes, 0, plainTextBytes.Length);
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
          }
        }
