     public string RsaDecryption(byte[] cipherText, string privateKey)
        {
            var cspDecryption = new RSACryptoServiceProvider();
            cspDecryption.FromXmlString(privateKey);
            
            var bytesPlainTextData = cspDecryption.Decrypt(cipherText, false);
            return Encoding.UTF8.GetString(bytesPlainTextData);
        }
    public byte[] RsaEncryption(string plainText, string publicKey)
        {
            var cspEncryption = new RSACryptoServiceProvider();
            cspEncryption.FromXmlString(publicKey);
            
            var bytesPlainTextData = Encoding.UTF8.GetBytes(plainText);
            var bytesCypherText = cspEncryption.Encrypt(bytesPlainTextData, false);
            return bytesCypherText;
        }
