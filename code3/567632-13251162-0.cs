    private static byte[] SimpleEncrypt(string value, string key)
    {
        var simpleAlgorithm = GetSimpleAlgorithm(key);
        CryptographicKey encryptKey = simpleAlgorithm.Item1;
        IBuffer IV = simpleAlgorithm.Item2;
        var encryptedBuffer = CryptographicEngine.Encrypt(encryptKey, CryptographicBuffer.ConvertStringToBinary(value, BinaryStringEncoding.Utf8), IV);
        var result = new byte[encryptedBuffer.Length];
        CryptographicBuffer.CopyToByteArray(encryptedBuffer, out result);
        return result;
    }
    private static Tuple<CryptographicKey, IBuffer> GetSimpleAlgorithm(string key)
    {
        var provider = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesCbcPkcs7);
        var keyAsBinary = CryptographicBuffer.ConvertStringToBinary(key, BinaryStringEncoding.Utf8);
        var source = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha256).HashData(keyAsBinary);
        byte[] sourceArray = new byte[16];
        CryptographicBuffer.CopyToByteArray(source, out sourceArray);
        var shortKey = CryptographicBuffer.CreateFromByteArray(sourceArray.Take((int)provider.BlockLength).ToArray());
            
        return new Tuple<CryptographicKey,IBuffer>(provider.CreateSymmetricKey(source), shortKey);
    }
