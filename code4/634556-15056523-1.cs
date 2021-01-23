    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using Newtonsoft.Json;
    class SecureJsonSerializer<T>
        where T : class
    {
        private readonly string filePath;
        private readonly ICryptoTransform encryptor;
        private readonly ICryptoTransform decryptor;
        private const string Password = "some password";
        private static readonly byte[] passwordBytes = Encoding.ASCII.GetBytes(Password);
        public SecureJsonSerializer(string filePath)
        {
            this.filePath = filePath;
            var rmCrypto = GetAlgorithm();
            this.encryptor = rmCrypto.CreateEncryptor();
            this.decryptor = rmCrypto.CreateDecryptor();
        }
        private static RijndaelManaged GetAlgorithm()
        {
            var algorithm = new RijndaelManaged();
            int bytesForKey = algorithm.KeySize / 8;
            int bytesForIV = algorithm.BlockSize / 8;
            algorithm.Key = key.GetBytes(bytesForKey);
            algorithm.IV = key.GetBytes(bytesForIV);
            return algorithm;
        }
        public void Save(T obj)
        {
            using (var writer = new StreamWriter(new CryptoStream(File.Create(this.filePath), this.encryptor, CryptoStreamMode.Write)))
            {
                writer.Write(JsonConvert.SerializeObject(obj));
            }
        }
        public T Load()
        {
            using (var reader = new StreamReader(new CryptoStream(File.OpenRead(this.filePath), this.decryptor, CryptoStreamMode.Read)))
            {
                return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }
        }
    }
