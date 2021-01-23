               // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            if (encryptedString.Length != aesAlg.BlockSize)
                            {
                                // Handle invalid token here.
                            }
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
