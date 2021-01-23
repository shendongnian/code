    using Windows.Security.Cryptography.Core;
    using Windows.Security.Cryptography;
    using Windows.Storage.Streams;
    ....
    // Use AES, CBC mode with PKCS#7 padding (good default choice)
    SymmetricKeyAlgorithmProvider aesCbcPkcs7 = 
        SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesCbcPkcs7);
    // Create an AES 128-bit (16 byte) key
    CryptographicKey key = 
        aesCbcPkcs7.CreateSymmetricKey(CryptographicBuffer.GenerateRandom(16));
    // Creata a 16-bit initialization vector
    IBuffer iv = CryptographicBuffer.GenerateRandom(aesCbcPkcs7.BlockLength);
    // Encrypt the data
    byte[] plainText = Encoding.UTF8.GetBytes("Hello, world!"); // Data to encrypt
    byte[] cipherText = CryptographicEngine.Encrypt(
        key, plainText.AsBuffer(), iv).ToArray();
    // Reverse the encryption
    string newPlainText = new string(
        Encoding.UTF8.GetChars(CryptographicEngine.Decrypt(
            key, cipherText.AsBuffer(), iv).ToArray()));
    // newPlainText contains "Hello, world!"
