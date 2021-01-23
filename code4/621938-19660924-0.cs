        public static string Signature(this FileInfo input)
        {
            MD5CryptoServiceProvider cryptoTransform = new MD5CryptoServiceProvider();
            FileStream fs = new FileStream(input.FullName, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            byte[] data = reader.ReadBytes((int)fs.Length);
            string hash = BitConverter.ToString(cryptoTransform.ComputeHash(data)).Replace("-", "");
            reader.Close();
            fs.Close();
            return hash;
        }
