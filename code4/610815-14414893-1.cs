    private static Byte[] Encrypt(String toEncrypt, Byte[] Key, Byte[] IV)
    {
        CryptoStream streamCrypto = null;
        MemoryStream streamMemory = null;
        RijndaelManaged aes = null;
        StreamWriter streamWriter = null;
        try
        {
            aes = new RijndaelManaged();
            aes.Key = Key;
            aes.IV = IV;
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            streamMemory = new MemoryStream();
            streamCrypto = new CryptoStream(streamMemory, encryptor, CryptoStreamMode.Write);
            streamWriter = new StreamWriter(streamCrypto);
            streamWriter.Write(toEncrypt);
        }
        finally
        {
            if (streamWriter != null)
                streamWriter.Close();
            if (streamCrypto != null)
                streamCrypto.Close();
            if (streamMemory != null)
                streamMemory.Close();
            if (aes != null)
                aes.Clear();
        }
        return streamMemory.ToArray();
    }
    public static String Decrypt(Byte[] toDecrypt, Byte[] Key, Byte[] IV)
    {
        CryptoStream streamCrypto = null;
        MemoryStream streamMemory = null;
        RijndaelManaged aes = null;
        StreamReader streamReader = null;
        String output = null;
        try
        {
            aes = new RijndaelManaged();
            aes.Key = Key;
            aes.IV = IV;
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            streamMemory = new MemoryStream(toDecrypt);
            streamCrypto = new CryptoStream(streamMemory, decryptor, CryptoStreamMode.Read);
            streamReader = new StreamReader(streamCrypto);
            output = streamReader.ReadToEnd();
        }
        finally
        {
            if (streamReader != null)
                streamReader.Close();
            if (streamCrypto != null)
                streamCrypto.Close();
            if (streamMemory != null)
                streamMemory.Close();
            if (aes != null)
                aes.Clear();
        }
        return output;
    }
