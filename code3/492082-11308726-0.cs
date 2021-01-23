    public static string Encrypt2(string plainText)
        {
            string PassPhrase = "somepassphrase";
            string SaltValue = "somesalt";
            int PasswordIterations = 0; //amend to match java encryption iteration
            string InitVector = "someiv";
            int KeySize = 0; //amend to match java encryption key size
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(
                                                            PassPhrase,
                                                            saltValueBytes,
                                                            PasswordIterations);
            byte[] keyBytes = password.GetBytes(KeySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                             keyBytes,
                                                             initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         encryptor,
                                                         CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string cipherText = Convert.ToBase64String(cipherTextBytes);
            return cipherText;
        }
