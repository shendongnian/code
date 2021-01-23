                using (CryptoStream stream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter encrypted = new StreamWriter(stream))
                    {
                        encrypted.Write(inputBuffer);
                    }
                }
                OutputFileStream.Write(memoryStream.GetBuffer(),
                    0, (int)memoryStream.Length);
            }
