    public class ShelfCache
    {
        public Shelf Data;
        public ShelfCache()
        {
            Data = new Shelf();
        }
        public void Write(string Filename)
        {           
            XmlSerializer CacheSerializer = new XmlSerializer(typeof(Shelf));
            TextWriter CacheWriter = new StreamWriter(Filename);
            CacheSerializer.Serialize(CacheWriter, Data);
            CacheWriter.Flush();
            CacheWriter.Close();
        }
        public void Read(string Filename)
        {
            Data = new Shelf();
            XmlSerializer CacheSerializer = new XmlSerializer(typeof(Shelf));
            TextReader CacheReader = new StreamReader(Filename);
            Data = (Shelf)CacheSerializer.Deserialize(CacheReader);
            CacheReader.Close();
        }
        public void WriteEncrypted(string Filename, string EncryptionKey = "")
        {
            string TempFile = System.IO.Path.GetTempFileName();
            Write(TempFile);
            EncryptFile(TempFile, Filename, EncryptionKey);
            File.Delete(TempFile);
        }
        public void ReadEncrypted(string Filename, string EncryptionKey = "")
        {
            string TempFile = System.IO.Path.GetTempFileName();
            DecryptFile(Filename, TempFile, EncryptionKey);
            Read(TempFile);
            File.Delete(TempFile);
        }
        private RijndaelManaged GetEncryptor(string Key = "", string Salt = "")
        {
            Key += Environment.ExpandEnvironmentVariables("%USERNAME%");
            Salt += Environment.ExpandEnvironmentVariables("%COMPUTERNAME%");
            Rfc2898DeriveBytes derivedKey = new Rfc2898DeriveBytes(Key, Encoding.Unicode.GetBytes(Salt));
            RijndaelManaged rijndaelCSP = new RijndaelManaged();
            rijndaelCSP.Key = derivedKey.GetBytes(rijndaelCSP.KeySize / 8);
            rijndaelCSP.IV = derivedKey.GetBytes(rijndaelCSP.BlockSize / 8);
            return rijndaelCSP;
        }
        private void EncryptFile(string Source, string Target, string EncryptionKey)
        {
            RijndaelManaged EncryptionProvider = GetEncryptor(EncryptionKey);
            ICryptoTransform Encryptor = EncryptionProvider.CreateEncryptor();
            FileStream SourceStream = new FileStream(Source, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            byte[] SourceBytes = new byte[(int)SourceStream.Length];
            SourceStream.Read(SourceBytes, 0, (int)SourceStream.Length);
            FileStream TargetStream = new FileStream(Target, FileMode.Create, FileAccess.Write);
            CryptoStream EncryptionStream = new CryptoStream(TargetStream, Encryptor, CryptoStreamMode.Write);
            EncryptionStream.Write(SourceBytes, 0, (int)SourceStream.Length);
            EncryptionStream.FlushFinalBlock();
            EncryptionProvider.Clear();
            EncryptionStream.Close();
            SourceStream.Close();
            TargetStream.Close();
        }
        private void DecryptFile(string Source, string Target, string EncryptionKey)
        {
            RijndaelManaged EncryptionProvider = GetEncryptor(EncryptionKey);
            ICryptoTransform Decryptor = EncryptionProvider.CreateDecryptor();
            FileStream SourceStream = new FileStream(Source, FileMode.Open, FileAccess.Read);
            CryptoStream DecryptionStream = new CryptoStream(SourceStream, Decryptor, CryptoStreamMode.Read);
            byte[] SourceBytes = new byte[(int)SourceStream.Length];
            int DecryptionLength = DecryptionStream.Read(SourceBytes, 0, (int)SourceStream.Length);
            FileStream TargetStream = new FileStream(Target, FileMode.Create, FileAccess.Write);
            TargetStream.Write(SourceBytes, 0, DecryptionLength);
            TargetStream.Flush();
            EncryptionProvider.Clear();
            DecryptionStream.Close();
            SourceStream.Close();
            TargetStream.Close();
        }
    }
