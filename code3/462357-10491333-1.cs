    DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) 
            {
                saveFileDialog1.FileName = openFileDialog1.SafeFileName;
                saveFileDialog1.ShowDialog();
                FileStream readFile = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                FileStream writeFile = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                writeFile.SetLength(0);
                byte[] storage = new byte[10000];
                long fileWritten = 0;
                long totlen = readFile.Length;
                int bytesToWrite;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(textBox1.Text));
                TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
                TDES.Key = TDESKey;
                TDES.Mode = CipherMode.ECB;
                TDES.Padding = PaddingMode.PKCS7;
                CryptoStream cryptStream = new CryptoStream(writeFile, TDES.CreateEncryptor(), CryptoStreamMode.Write);
                while (fileWritten < totlen)
                {
                    bytesToWrite = readFile.Read(storage, 0, 100);
                    cryptStream.Write(storage, 0, bytesToWrite);
                    fileWritten = fileWritten + bytesToWrite;
                }
                
                cryptStream.Close();
                TDES.Clear();
                HashProvider.Clear();
            }
