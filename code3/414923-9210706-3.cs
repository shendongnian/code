    public static string DecryptAesCryptoString(string cipherText, byte[] key, byte[] initiationVector)
    {
        byte[] decryptedByte;
        using (RijndaelManaged aesAlgorithm = new RijndaelManaged())
        {
            aesAlgorithm.Key = key;
            aesAlgorithm.IV = initiationVector;
            aesAlgorithm.Mode = CipherMode.ECB;
            using (ICryptoTransform decryptoTransform = aesAlgorithm.CreateDecryptor(aesAlgorithm.Key, aesAlgorithm.IV))
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                decryptedByte = decryptoTransform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            }
        }
        return Convert.ToBase64String(decryptedByte);
    }
