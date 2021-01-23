        static byte[] u8_Salt = new byte[] { 0x26, 0x19, 0x81, 0x4E, 0xA0, 0x6D, 0x95, 0x34, 0x26, 0x75, 0x64, 0x05, 0xF6 };
        public static string EncryptString(string plainText, string password)
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, u8_Salt);
            using (RijndaelManaged i_Alg = new RijndaelManaged { Key = pdb.GetBytes(32), IV = pdb.GetBytes(16) })
            {
                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, i_Alg.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] data = Encoding.UTF8.GetBytes(plainText);
                    cryptoStream.Write(data, 0, data.Length);
                    cryptoStream.FlushFinalBlock();
                    return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
                }
            }
        }
        public static string Decrypt(string cipherText, string password)
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, u8_Salt);
            using (RijndaelManaged i_Alg = new RijndaelManaged { Padding = PaddingMode.Zeros, Key = pdb.GetBytes(32), IV = pdb.GetBytes(16) })
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, i_Alg.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        byte[] data = Convert.FromBase64String(cipherText);
                        cryptoStream.Write(data, 0, data.Length);
                        cryptoStream.Flush();
                        return Encoding.UTF8.GetString(memoryStream.ToArray());
                    }
                }
            }
        }
