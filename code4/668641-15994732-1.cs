    public static class CryptoSerivces
    {
            //---------------------------------------------------------------------
            public static Byte[] AesEncrypt(Byte[] src, Byte[] key, Byte[] IV)
            {
                using (RijndaelManaged myRijndael = new RijndaelManaged())
                {
                    try
                    {
                        myRijndael.Mode = CipherMode.CBC;
                        myRijndael.Key = key;
                        myRijndael.IV = IV;
                        myRijndael.Padding = PaddingMode.PKCS7;
    
                        using (ICryptoTransform encryptor = myRijndael.CreateEncryptor())
                        using (MemoryStream msEncrypt = new MemoryStream())
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            csEncrypt.Write(src, 0, src.Length);
                            csEncrypt.FlushFinalBlock();
    
                            return msEncrypt.ToArray();
                        }
                    }
                    finally
                    {
                        myRijndael.Clear();
                    }
                }
            }
            //---------------------------------------------------------------------
            public static Byte[] AesDecrypt(Byte[] src, Byte[] key, Byte[] IV)
           {
            using (RijndaelManaged myRijndael = new RijndaelManaged())
            {
                try
                {
                    myRijndael.Mode = CipherMode.CBC;
                    myRijndael.Key = key;
                    myRijndael.IV = IV;
                    myRijndael.Padding = PaddingMode.PKCS7;
                    using (ICryptoTransform decryptor = myRijndael.CreateDecryptor())
                    using (MemoryStream msDecrypt = new MemoryStream())
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                    {
                        csDecrypt.Write(src, 0, src.Length);
                        csDecrypt.FlushFinalBlock();
                        return msDecrypt.ToArray();
                    }
                }
                finally
                {
                    myRijndael.Clear();
                }
            }
        }
    }
