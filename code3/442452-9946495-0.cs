    int plainByteCount = int.MinValue;
    // Create the streams used for decryption.
    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
    {
      using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
      {
        plainBytes = new byte[cipherText.Length];
        plainByteCount = cryptoStream.Read(plainBytes, 0, plainBytes.Length);
      }
    }
    string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, plainByteCount);
    return plainText;
