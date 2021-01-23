            private void DecryptFile(string inputFile, string outputFile)
        {
                string password = @"yourPWhere";
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = CreateKey(password);
                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
                RijndaelManaged RMCrypto = new RijndaelManaged();
                IV = CreateIV(password_mTxtBx.Text);
                
                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, IV),
                    CryptoStreamMode.Read);
                FileStream fsOut = new FileStream(outputFile.Remove(outputFile.Length - 4), FileMode.Create);
                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);
                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
            }
