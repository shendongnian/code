                InputFileStream.Read(inputBuffer, 0, (int)InputFileStream.Length);
                InputFileStream.Flush();
                InputFileStream.Close();
                using (MemoryStream msEncrypt = new MemoryStream(outputBuffer))
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(inputBuffer);
                            swEncrypt.Flush();
                            swEncrypt.Close();
                        }
                        csEncrypt.Flush();
                        csEncrypt.Close();
                    }
                    OutputFileStream.Write(outputBuffer, 0, (int)outputBuffer.Length);
                    OutputFileStream.Flush();
                    OutputFileStream.Close();
                }
