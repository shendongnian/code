    using System;
    using System.IO;
    using System.Text;
    using System.Security.Cryptography;
    using System.Runtime.Serialization.Formatters.Binary;
    
    class Test
    {
        static void Main()
        {
            byte[] data = Serialize("Some arbitrary test data", "pass");
            object x = Deserialize(data, "pass");
            Console.WriteLine(x);
        }
        
        private static SymmetricAlgorithm CreateCryptoServiceProvider(string key)
        {
            byte[] passwordHash;
            using (MD5 md5 = MD5.Create())
            {
                // It's not clear why you're taking the hash of the password...
                passwordHash = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
            }
            var crypt = new TripleDESCryptoServiceProvider();
            crypt.Key = passwordHash;
            crypt.Mode = CipherMode.CBC; // This is the default anyway - can remove
            crypt.Padding = PaddingMode.PKCS7; // Ditto
            // Fix this to use a randomly generated one and store it for real code.
            crypt.IV = new byte[crypt.BlockSize / 8];
            return crypt;
        }
        
        public static byte[] Serialize(object obj, string key)
        {
            var provider = CreateCryptoServiceProvider(key);
            
            using (MemoryStream memory = new MemoryStream())
            {
                using (CryptoStream stream = new CryptoStream(
                    memory, provider.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, obj);
                }
                return memory.ToArray();
            }
        }
    
        public static object Deserialize(byte[] inBytes, string key)
        {
            var provider = CreateCryptoServiceProvider(key);
            
            using (MemoryStream memory = new MemoryStream(inBytes))
            {
                using (CryptoStream stream = new CryptoStream(
                    memory, provider.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(stream);
                }
            }
        }
    
    }
