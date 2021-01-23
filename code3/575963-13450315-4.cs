    string cryptedUser = Encrypt(user, "your_secret_key_ABCDEFG");
    ....
    public string Encrypt(string stringToEncrypt, string key)
    {
        if (string.IsNullOrEmpty(stringToEncrypt))
            throw new ArgumentException("An empty string value cannot be encrypted.");
        if (string.IsNullOrEmpty(key))
            throw new ArgumentException("Cannot encrypt using an empty key.");
        CspParameters cspp = new CspParameters();
        cspp.KeyContainerName = key;
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspp);
        rsa.PersistKeyInCsp = true;
        byte[] bytes = rsa.Encrypt(UTF8Encoding.UTF8.GetBytes(stringToEncrypt), true);
        return BitConverter.ToString(bytes);
    }
    string clearText = Decrypt(cryptedText, "your_secret_key_ABCDEFG");
    ....
    public string Decrypt(string stringToDecrypt, string key)
    {
        string result = null;
        if (string.IsNullOrEmpty(stringToDecrypt))
            throw new ArgumentException("An empty string value cannot be encrypted.");
        if (string.IsNullOrEmpty(key))
            throw new ArgumentException("Cannot decrypt using an empty key");
        try
        {
            CspParameters cspp = new CspParameters();
            cspp.KeyContainerName = key;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;
            string[] decryptArray = stringToDecrypt.Split(new string[] { "-" }, 
                                     StringSplitOptions.None);
            byte[] decryptByteArray = Array.ConvertAll<string, byte>
                                     (decryptArray, (s => Convert.ToByte(byte.Parse(s,
                                     System.Globalization.NumberStyles.HexNumber))));
            byte[] bytes = rsa.Decrypt(decryptByteArray, true);
            result = System.Text.UTF8Encoding.UTF8.GetString(bytes);
        }
        finally
        {
            // no need for further processing
        }
        return result;
    }
