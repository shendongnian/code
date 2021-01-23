     public string RsaDecryption(string keyType, byte[] cipherText, string privateKey)
        {
            var cspDecryption = new RSACryptoServiceProvider();
            keyType = keyType.ToUpper();
            cspDecryption.FromXmlString(privateKey);
            
            var bytesPlainTextData = cspDecryption.Decrypt(cipherText, false);
            return Encoding.UTF8.GetString(bytesPlainTextData);
        }
    public byte[] RsaEncryption(string keyType, string plainText, string publicKey)
        {
            var cspEncryption = new RSACryptoServiceProvider();
            keyType = keyType.ToUpper();
            cspEncryption.FromXmlString(publicKey);
            
            var bytesPlainTextData = Encoding.UTF8.GetBytes(plainText);
            var bytesCypherText = cspEncryption.Encrypt(bytesPlainTextData, false);
            return bytesCypherText;
        }
