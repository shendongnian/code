    public T Decrypt<T>(byte[] encryptedValue)
    {
        using (var decryptor = rijndael.CreateDecryptor())
        using (var stream = new MemoryStream(encryptedValue))
        using (var crypto = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
        {
            var ser = new XmlSerializer(typeof(T));
            return (T)ser.Deserialize(crypto);
        }
    }
