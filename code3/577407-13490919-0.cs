    public string Encrypt(string clearText, string Password)
        {
            //Convert text to bytes
            byte[] clearBytes =
              System.Text.Encoding.Unicode.GetBytes(clearText);
            //We will derieve our Key and Vectore based on following 
            //password and a random salt value, 13 bytes in size.
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            byte[] encryptedData = Encrypt(clearBytes,
                     pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encryptedData);
        }
        //Call following function to decrypt data
        public string Decrypt(string cipherText, string Password)
        {
            //Convert base 64 text to bytes
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            //We will derieve our Key and Vectore based on following 
            //password and a random salt value, 13 bytes in size.
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 
            0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
            byte[] decryptedData = Decrypt(cipherBytes,
                pdb.GetBytes(32), pdb.GetBytes(16));
            //Converting unicode string from decrypted data
            return Encoding.Unicode.GetString(decryptedData);
        }
        public byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            byte[] encryptedData;
            //Create stream for encryption
            using (MemoryStream ms = new MemoryStream())
            {
                //Create Rijndael object with key and vector
                using (Rijndael alg = Rijndael.Create())
                {
                    alg.Key = Key;
                    alg.IV = IV;
                    //Forming cryptostream to link with data stream.
                    using (CryptoStream cs = new CryptoStream(ms,
                       alg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        //Write all data to stream.
                        cs.Write(clearData, 0, clearData.Length);
                    }
                    encryptedData = ms.ToArray();
                }
            }
            return encryptedData;
        }
        public byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            byte[] decryptedData;
            //Create stream for decryption
            using (MemoryStream ms = new MemoryStream())
            {
                //Create Rijndael object with key and vector
                using (Rijndael alg = Rijndael.Create())
                {
                    alg.Key = Key;
                    alg.IV = IV;
                    //Forming cryptostream to link with data stream.
                    using (CryptoStream cs = new CryptoStream(ms,
                        alg.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        //Write all data to stream.
                        cs.Write(cipherData, 0, cipherData.Length);
                    }
                    decryptedData = ms.ToArray();
                }
            }
            return decryptedData;
        }
