        static void EncryptFile(string sInputFilename, string sOutputFilename, byte[] key, byte[] iv)
        {
            FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);
            using (AesCryptoServiceProvider encryptor = new AesCryptoServiceProvider())
            {
                encryptor.Key = key;
                encryptor.IV = iv;
                ICryptoTransform transform = encryptor.CreateEncryptor();
                using (CryptoStream cryptostream = new CryptoStream(fsEncrypted, transform, CryptoStreamMode.Write))
                {
                    byte[] bytearrayinput = new byte[fsInput.Length];
                    fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                    cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
                }
                fsInput.Close();
                fsEncrypted.Close();
            }
        }
        static void DecryptFile(string sInputFilename, string sOutputFilename, byte[] key, byte[] iv)
        {
            using (AesCryptoServiceProvider encryptor = new AesCryptoServiceProvider())
            {
                encryptor.Key = key;
                encryptor.IV = iv;
                using (FileStream fsread = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read))
                {
                    using (ICryptoTransform transform = encryptor.CreateDecryptor())
                    {
                        using (CryptoStream cryptostream = new CryptoStream(fsread, transform, CryptoStreamMode.Read))
                        {
                            using (BinaryWriter fsDecrypted = new BinaryWriter(File.Open(sOutputFilename, FileMode.Create)))
                            {
                                byte[] buffer = new byte[1024];
                                var read = cryptostream.Read(buffer, 0, buffer.Length);
                                while (read > 0)
                                {
                                    fsDecrypted.Write(buffer, 0, read);
                                    read = cryptostream.Read(buffer, 0, buffer.Length);
                                }
                                fsDecrypted.Flush();
                                cryptostream.Flush();
                            }
                        }
                    }
                }
            }
        }
