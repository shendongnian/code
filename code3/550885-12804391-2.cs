    using System;
    using System.Text;
    using System.Security.Cryptography;
    
    public class Program
    {
        private const string key = "key";
        private const string message = "message";
        private static readonly Encoding encoding = Encoding.UTF8; 
    
        static void Main(string[] args)
        {
            var keyByte = encoding.GetBytes(key);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                hmacsha256.ComputeHash(encoding.GetBytes(message));
    
                Console.WriteLine("Result: {0}", ByteToString(hmacsha256.Hash));
            }
        }
        static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
                sbinary += buff[i].ToString("X2"); /* hex format */
            return sbinary;
        }    
    }
