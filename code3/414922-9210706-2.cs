    public static string EncryptWithAes(string plainText, byte[] key, byte[] initiationVector)
            {
                byte[] cryptoBytes = Convert.FromBase64String(plainText);
                using (RijndaelManaged aesAlgorithm = new RijndaelManaged())
                {
                    aesAlgorithm.Key = key;
                    aesAlgorithm.IV = initiationVector;
                    aesAlgorithm.Mode = CipherMode.ECB;
                    using (ICryptoTransform encryptoTransform = aesAlgorithm.CreateEncryptor(aesAlgorithm.Key, aesAlgorithm.IV))
                    {
                        cryptoBytes = encryptoTransform.TransformFinalBlock(cryptoBytes, 0, cryptoBytes.Length);
                    }
                }
                return Convert.ToBase64String(cryptoBytes);
            }
