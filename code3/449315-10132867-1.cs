    using System;
    using System.Text;
    using System.Security.Cryptography;
    
    namespace RsaForDotNet
    {
        class Program
        {
            static void Main(string[] args)
            {
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(512);
                var encrypted_msg = rsa.Encrypt(Encoding.UTF8.GetBytes("Secret Data"), false);
                var encoded_msg = Convert.ToBase64String(encrypted_msg);
                Console.WriteLine(encoded_msg);
                var decoded_msg = Convert.FromBase64String(encoded_msg);
                var decrypted_msg = Encoding.UTF8.GetString(rsa.Decrypt(decoded_msg, false));
                Console.WriteLine(decrypted_msg);
            }
        }
    }
