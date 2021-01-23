    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using System.IO;
    
    namespace _3dtest
    {
        class Program
        {
            static byte[] TestEncrypt(string data)
            {
                byte[] plainText = System.Text.Encoding.ASCII.GetBytes(data);
                TripleDES des3 = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
                des3.Mode = CipherMode.CBC;
                des3.Key = System.Text.Encoding.ASCII.GetBytes("12656b2e4ba2f22e");
                des3.IV = System.Text.Encoding.ASCII.GetBytes("d566gdbc");
                ICryptoTransform transform = des3.CreateEncryptor();
                MemoryStream memStreamEncryptedData = new MemoryStream();
                CryptoStream encStream = new CryptoStream(memStreamEncryptedData,
                    transform, CryptoStreamMode.Write);
                encStream.Write(plainText, 0, plainText.Length);
                encStream.FlushFinalBlock();
                encStream.Close();
                byte[] cipherText = memStreamEncryptedData.ToArray();
                return cipherText;
            }
    
            static void Main(string[] args)
            {
                var info = TestEncrypt("password");
                foreach (byte b in info)
                {
                    Console.Write(b.ToString());
                    Console.Write(", ");
                }
                Console.WriteLine();
            }
        }
    }
