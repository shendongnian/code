    private static string SignString(string data)
    {
        string cspBlobString = //cspBlob
        var keyBlob = CryptographicBuffer.DecodeFromBase64String(cspBlobString);
        AsymmetricKeyAlgorithmProvider rsa = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithmNames.RsaPkcs1);
        CryptographicKey key = rsa.ImportPublicKey(keyBlob, CryptographicPublicKeyBlobType.Capi1PublicKey);
        IBuffer plainBuffer = CryptographicBuffer.ConvertStringToBinary(data, BinaryStringEncoding.Utf8);
        IBuffer encryptedBuffer = CryptographicEngine.Encrypt(key, plainBuffer, null);
        byte[] encryptedBytes;
        CryptographicBuffer.CopyToByteArray(encryptedBuffer, out encryptedBytes);
        return Convert.ToBase64String(encryptedBytes);
    }
