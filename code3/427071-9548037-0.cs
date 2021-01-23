    using System;
    using System.Text;
    using System.Security.Cryptography;
    using System.IO;
    
    namespace AesCFB8Mode
    {
        class AESCFB8Example
        {
            static void Example()
            {
                //
                // Encrypt a small sample of data
                //
                String Plain = "The quick brown fox";
                byte[] plainBytes = Encoding.UTF8.GetBytes(Plain);
                Console.WriteLine("plaintext length is " + plainBytes.Length);
                Console.WriteLine("Plaintext is " + BitConverter.ToString(plainBytes));
    
                byte [] savedKey = new byte[16];
                byte [] savedIV = new byte[16];
                byte[] cipherBytes;
                using (RijndaelManaged Aes128 = new RijndaelManaged())
                {
                    //
                    // Specify a blocksize of 128, and a key size of 128, which make this
                    // instance of RijndaelManaged an instance of AES 128.
                    //
                    Aes128.BlockSize = 128;
                    Aes128.KeySize = 128;
    
                    //
                    // Specify CFB8 mode
                    //
                    Aes128.Mode = CipherMode.CFB;
                    Aes128.FeedbackSize = 8;
                    Aes128.Padding = PaddingMode.None;
                    //
                    // Generate and save random key and IV.
                    //
                    Aes128.GenerateKey();
                    Aes128.GenerateIV();
    
                    Aes128.Key.CopyTo(savedKey, 0);
                    Aes128.IV.CopyTo(savedIV, 0);
    
                    using (var encryptor = Aes128.CreateEncryptor())
                    using (var msEncrypt = new MemoryStream())
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var bw = new BinaryWriter(csEncrypt, Encoding.UTF8))
                    {
                        bw.Write(plainBytes);
                        bw.Close();
    
                        cipherBytes = msEncrypt.ToArray();
                        Console.WriteLine("Cipher length is " + cipherBytes.Length);
                        Console.WriteLine("Cipher text is " + BitConverter.ToString(cipherBytes));
                    }
                }
    
                //
                // Now decrypt the cipher back to plaintext
                //
    
                using (RijndaelManaged Aes128 = new RijndaelManaged())
                {
                    Aes128.BlockSize = 128;
                    Aes128.KeySize = 128;
                    Aes128.Mode = CipherMode.CFB;
                    Aes128.FeedbackSize = 8;
                    Aes128.Padding = PaddingMode.None;
    
                    Aes128.Key = savedKey;
                    Aes128.IV = savedIV;
    
                    using (var decryptor = Aes128.CreateDecryptor())
                    using (var msEncrypt = new MemoryStream(cipherBytes))
                    using (var csEncrypt = new CryptoStream(msEncrypt, decryptor, CryptoStreamMode.Read))
                    using (var br = new BinaryReader(csEncrypt, Encoding.UTF8))
                    {
                        //csEncrypt.FlushFinalBlock();
                        plainBytes = br.ReadBytes(cipherBytes.Length);
    
                        Console.WriteLine("Decrypted plain length is " + plainBytes.Length);
                        Console.WriteLine("Decrypted plain text is " + BitConverter.ToString(plainBytes));
                    }
                }
            }
    
            static void Main(string[] args)
            {
                Example();
            }
        }
    }
