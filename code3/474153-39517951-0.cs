       //ENCRYPT
       public static byte[] EncryptDES(byte[] clearData, byte[] key) 
       { 
           DES desEncrypt = new DESCryptoServiceProvider(); 
           desEncrypt.Mode = CipherMode.ECB; 
           desEncrypt.Key = key; 
           ICryptoTransform transForm = desEncrypt.CreateEncryptor(); 
           MemoryStream encryptedStream = new MemoryStream(); 
           CryptoStream cryptoStream = new CryptoStream(encryptedStream, transForm, CryptoStreamMode.Write); 
           cryptoStream.Write(clearData, 0, clearData.Length);
           cryptoStream.FlushFinalBlock();
           return encryptedStream.ToArray();
       }
       //DECRYPT
       public static byte[] DecryptDES(byte[] clearData, byte[] key)
       {
           DES desDecrypt = new DESCryptoServiceProvider();
           desDecrypt.Mode = CipherMode.ECB;
           desDecrypt.Key = key;
           ICryptoTransform transForm = desDecrypt.CreateDecryptor();
           MemoryStream decryptedStream = new MemoryStream();
           CryptoStream cryptoStream = new CryptoStream(decryptedStream, transForm, CryptoStreamMode.Write);
           cryptoStream.Write(clearData, 0, clearData.Length);
           cryptoStream.FlushFinalBlock();
           return decryptedStream.ToArray();
       }
