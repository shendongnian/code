    private string RSAEncrypt(string value)
    {
        byte[] plaintext = Encoding.Unicode.GetBytes(value);
        CspParameters cspParams = new CspParameters();
        cspParams.KeyContainerName = _rsaContainerName;
        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048,cspParams))
        {
            byte[] encryptedData = RSA.Encrypt(plaintext, false);
            return Convert.ToBase64String(encryptedData);
        }
    }
    private string RSADecrypt(string value)
    {
        byte[] encryptedData = Convert.FromBase64String(value);
        CspParameters cspParams = new CspParameters();
        cspParams.KeyContainerName = _rsaContainerName;
        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048,cspParams))
        { 
            byte[] decryptedData = RSA.Decrypt(encryptedData,false);
            return Encoding.Unicode.GetString(decryptedData);
        }
    }
