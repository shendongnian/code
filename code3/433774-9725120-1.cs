    var tempData = "This is the text to encrypt. It's not much, but it's all there is.";
    
    using (var rijCrypto = new RijndaelManaged())
    {
        byte[] encryptedData;
        rijCrypto.Padding = System.Security.Cryptography.PaddingMode.ISO10126;
        rijCrypto.KeySize = 256;
        using (var input = new MemoryStream(Encoding.Unicode.GetBytes(tempData)))
        using (var output = new MemoryStream())
        {
            var encryptor = rijCrypto.CreateEncryptor();
    
            using (var cryptStream = new CryptoStream(output, encryptor, CryptoStreamMode.Write))
            {
                var buffer = new byte[1024];
                var read = input.Read(buffer, 0, buffer.Length);
                while (read > 0)
                {
                    cryptStream.Write(buffer, 0, read);
                    read = input.Read(buffer, 0, buffer.Length);
                }
                cryptStream.FlushFinalBlock();
                encryptedData = output.ToArray();
            }
        }
    
        using (var input = new MemoryStream(encryptedData))
        using (var output = new MemoryStream())
        {
            var decryptor = rijCrypto.CreateDecryptor();
            using (var cryptStream = new CryptoStream(input, decryptor, CryptoStreamMode.Read))
            {
                var buffer = new byte[1024];
                var read = cryptStream.Read(buffer, 0, buffer.Length);
                while (read > 0)
                {
                     output.Write(buffer, 0, read);
                     read = cryptStream.Read(buffer, 0, buffer.Length);
                }
                cryptStream.Flush();
                var result = Encoding.Unicode.GetString(output.ToArray());
            }
        }
    }
