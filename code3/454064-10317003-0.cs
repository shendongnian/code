    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        using System.IO;
        using System.Security.Cryptography;
    
        class Program
        {
            static void Main(string[] args)
            {
    
                if (args.Length == 0)
                {
                    Console.WriteLine("<key> <iv> <encryptedfile> <outputdecryptedfile>");
                    Environment.Exit(-1);
                }
    
                //Console.ReadLine();
                byte[] encryptionKey = StringToByteArray(args[0]);
                byte[] encryptionIV = StringToByteArray(args[1]);
    
                try
                {
                    using (FileStream outputFileStream = new FileStream(args[3], FileMode.CreateNew))
                    {
                        using (FileStream inputFileStream = new FileStream(args[2], FileMode.Open))
                        {
                            using (var aes = new AesManaged { Key = encryptionKey, IV = encryptionIV, Mode = CipherMode.CBC })
                            using (var encryptor = aes.CreateDecryptor())
                           using (var cryptoStream = new CryptoStream(inputFileStream, encryptor, CryptoStreamMode.Read))
                            {
                                cryptoStream.CopyTo(outputFileStream);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }            
            }
    
            public static byte[] StringToByteArray(string hex)
            {
                return Enumerable.Range(0, hex.Length)
                                 .Where(x => x % 2 == 0)
                                 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                                 .ToArray();
            }
            
        }
    }
