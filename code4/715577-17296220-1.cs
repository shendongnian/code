     public class DeltaGeIO
    {
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private const string initVector = "aa00bb11cc22dd33";
        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;
        private string debug;
        public string cryptDecryptScript(string nameFileToCrypt)
        {
            try
            {
                string prova = writeVBScriptEncrypt(nameFileToCrypt, "");
                prova = writeVBScriptDecrypt("testCrypt.txt");
                return prova;
            }
            catch
            {
                return debug;
            }
        }
        public string writeVBScriptEncrypt(string nameFile, string nameScript)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(nameFile);
            byte[] encryptedBytes = this.EncryptBytes(bytes, "Promosrl2006!");
            try
            {
                File.Delete("testCrypt.txt");
            }
            catch
            {
                debug = "WVBSSE - i cannot delete testCrypt.txt file";
            }
            File.WriteAllBytes("testCrypt.txt", encryptedBytes);
            return "OK file Encrypted";
        }
        public string writeVBScriptDecrypt(string nameFile)
        {
           var encryptedBytes = File.ReadAllBytes(nameFile);
           byte[] decryptedBytes = this.DecryptBytes(encryptedBytes, "Promosrl2006!");
           System.IO.File.WriteAllBytes("testDecrypt.vbs", decryptedBytes);
            try
            {
                System.IO.File.Delete("testCrypt.txt");
            }
            catch
            {
                debug = "WVBSSD - i cannot delete testCrypt.txt file";
            }
            return "OK file Decrypted";
        }
        private byte[] EncryptBytes(byte[] plainText, string passPhrase)
        {
           byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
           byte[] plainTextBytes = plainText;
           PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
           byte[] keyBytes = password.GetBytes(keysize / 8);
           using (RijndaelManaged symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC})
           {
              using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
              using (MemoryStream memoryStream = new MemoryStream())
              using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
              {
                 cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                 cryptoStream.FlushFinalBlock();
                 byte[] cipherTextBytes = memoryStream.ToArray();
                 return cipherTextBytes;
              }
           }
        }
        private byte[] DecryptBytes(byte[] cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = cipherText;
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            using (RijndaelManaged symmetricKey = new RijndaelManaged(){Mode = CipherMode.CBC})
            using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            {
               byte[] buffer = new byte[cipherTextBytes.Length];
               int decryptedByteCount = cryptoStream.Read(buffer, 0, buffer.Length);
               byte[] copy = new byte[decryptedByteCount];
               Array.Copy(buffer, copy, decryptedByteCount);
               return copy;
            }
        }
    }
