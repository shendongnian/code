    private void EncryptFile(string inputFile, string outputFile)
            {
                string password = @"yourPWhere";
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = CreateKey(password);
                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
                RijndaelManaged RMCrypto = new RijndaelManaged();
                IV = CreateIV(password_mTxtBx.Text);
                
                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key,IV),
                    CryptoStreamMode.Write);
                FileStream fsIn = new FileStream(inputFile, FileMode.Open);
                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);
                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
