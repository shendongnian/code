    using System;
    using System.IO;
    using System.Security.Cryptography;
    
    class Test
    {
        static void Main(string[] args)
        {
            using (HashAlgorithm hashSHA1 = new SHA1Managed())
            {
                // Actual data doesn't matter
                using (Stream data = new MemoryStream())
                {
                    byte[] hash = hashSHA1.ComputeHash(data);
                    
                    Console.WriteLine(BitConverter.ToString(hash).Replace("-", ""));
                }
            }
        }
    }
