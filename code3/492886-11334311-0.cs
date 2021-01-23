    String str = "String To Encrypt";
    IBuffer buf = CryptographicBuffer.ConvertStringToBinary(str,BinaryStringEncoding.Utf16BE);
    String AsymmetricAlgName = Windows.Security.Cryptography.Core.AsymmetricAlgorithmNames.RsaPkcs1;
    AsymmetricKeyAlgorithmProvider asym = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgName);
    CryptographicKey key = asym.CreateKeyPair(512);
    IBuffer enc = CryptographicEngine.Encrypt(key, buf, null);
    byte[] encryptedbyteArr;
    CryptographicBuffer.CopyToByteArray(enc, out encryptedbyteArr);
    String encryptedBase64Str = Convert.ToBase64String(encryptedbyteArr);
    
    
    //Export the private Key in WinCapi format
    
    byte[] privatekeyBytes;
    CryptographicBuffer.CopyToByteArray(key.Export(CryptographicPrivateKeyBlobType.Capi1PrivateKey), out privatekeyBytes);
    String privatekeyBase64 = Convert.ToBase64String(privatekeyBytes);
