     UnicodeEncoding ue = new UnicodeEncoding();
                   
                    byte[] key = ue.GetBytes(password);
                    string cryptFile = outputFile;
                    using (FileStream fileCrypt = new FileStream(cryptFile, FileMode.Create))
                    {
                        using (AesManaged encrypt = new AesManaged())
                        {
                            using (CryptoStream cs = new CryptoStream(fileCrypt, encrypt.CreateEncryptor(key, key), CryptoStreamMode.Write))
                            {
                                using (FileStream fileInput = new FileStream(inputFile, FileMode.Open))
                                {
                                    encrypt.KeySize = 256;
                                    encrypt.BlockSize = 128;
                                    int data;
                                    while ((data = fileInput.ReadByte()) != -1)
                                        cs.WriteByte((byte)data);
                                }
                            }
                        }
                    }
