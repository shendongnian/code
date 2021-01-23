    /// Encrypts a file using Rijndael algorithm.
    ///</summary>
    ///<param name="inputFile"></param>
    ///<param name="outputFile"></param>
    private void EncryptFile(string inputFile, string outputFile)
    {
    
        try
        {
            string password = @"myKey123"; // Your Key Here
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);
    
            string cryptFile = outputFile;
            FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
    
            RijndaelManaged RMCrypto = new RijndaelManaged();
    
            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateEncryptor(key, key),
                CryptoStreamMode.Write);
    
            FileStream fsIn = new FileStream(inputFile, FileMode.Open);
    
            int data;
            while ((data = fsIn.ReadByte()) != -1)
                cs.WriteByte((byte)data);
    
            
            fsIn.Close();
            cs.Close();
            fsCrypt.Close();
        }
        catch
        {
            MessageBox.Show("Encryption failed!", "Error");
        }
    }
    
    ///
    /// Decrypts a file using Rijndael algorithm.
    ///</summary>
    ///<param name="inputFile"></param>
    ///<param name="outputFile"></param>
    private void DecryptFile(string inputFile, string outputFile)
    {
    
        {
            string password = @"myKey123"; // Your Key Here
    
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);
    
            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
    
            RijndaelManaged RMCrypto = new RijndaelManaged();
    
            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateDecryptor(key, key),
                CryptoStreamMode.Read);
    
            FileStream fsOut = new FileStream(outputFile, FileMode.Create);
    
            int data;
            while ((data = cs.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);
    
            fsOut.Close();
            cs.Close();
            fsCrypt.Close();
    
        }
    }
