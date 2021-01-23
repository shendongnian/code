    private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new OpenFileDialog
                    {
                        Filter = "All Files (*.*)|",
                        InitialDirectory = @"Desktop",
                        Title = "Please select a file to encrypt."
                    };
                dialog.ShowDialog();
                string inputFile = dialog.FileName;
                const string password = @"secrets";
                var fileInfo = new FileInfo(inputFile);
                if(fileInfo.Directory != null)
                {
                    string cryptFile = Path.Combine(fileInfo.Directory.ToString(),
                                                    Path.GetRandomFileName());
                
                    using (var rijndael = InitSymmetric(Rijndael.Create(), password, 256))
                    {
                    
                        using(var fsCrypt = new FileStream(cryptFile, FileMode.Create))
                        {
                            using (var cs = new CryptoStream(fsCrypt,
                                                             rijndael.CreateEncryptor(),
                                                             CryptoStreamMode.Write))
                            {
                                using (var fsIn = new FileStream(inputFile, FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsIn.ReadByte()) != -1)
                                    {
                                        cs.WriteByte((byte)data);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static SymmetricAlgorithm InitSymmetric(SymmetricAlgorithm algorithm, string password, int keyBitLength)
        {
            var salt = new byte[] { 1, 3, 66, 234, 73, 48, 134, 69, 250, 6 };
            const int iterations = 145;
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, iterations);
            if (!algorithm.ValidKeySize(keyBitLength))
                throw new InvalidOperationException("Invalid size key");
            algorithm.Key = rfc2898DeriveBytes.GetBytes(keyBitLength / 8);
            algorithm.IV = rfc2898DeriveBytes.GetBytes(algorithm.BlockSize / 8);
            return algorithm;
        }
 
