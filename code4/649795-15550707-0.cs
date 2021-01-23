        byte[] key = // put your 16-bytes private key here
        byte[] iv = Guid.NewGuid().ToByteArray(); // or anything that varies and you can carry
        string s = EncryptUInt64(ul, key, iv); // encode
        ulong dul = DecryptUInt64(s, key, iv).Value; // decode if possible
        public static string EncryptUInt64(ulong ul, byte[] key, byte[] iv)
        {
            using (MemoryStream output = new MemoryStream())
            using (var algo = TripleDES.Create())
            {
                algo.Padding = PaddingMode.None;
                using (CryptoStream stream = new CryptoStream(output, algo.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                {
                    byte[] ulb = BitConverter.GetBytes(ul);
                    stream.Write(ulb, 0, ulb.Length);
                }
                return BitConverter.ToUInt64(output.ToArray(), 0).ToString("x16");
            }
        }
        public static ulong? DecryptUInt64(string text, byte[] key, byte[] iv)
        {
            if (text == null)
                return null;
            ulong ul;
            if (!ulong.TryParse(text, NumberStyles.HexNumber, null, out ul))
                return null;
            using (MemoryStream input = new MemoryStream(BitConverter.GetBytes(ul)))
            using (var algo = TripleDES.Create())
            {
                algo.Padding = PaddingMode.None;
                using (CryptoStream stream = new CryptoStream(input, algo.CreateDecryptor(key, iv), CryptoStreamMode.Read))
                {
                    byte[] olb = new byte[8];
                    try
                    {
                        stream.Read(olb, 0, olb.Length);
                    }
                    catch
                    {
                        return null;
                    }
                    return BitConverter.ToUInt64(olb, 0);
                }
            }
        }
