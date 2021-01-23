    public static byte[] TripleDESEncrypt(byte[] plainText, byte[] key1, byte[] key2, byte[] key3)
    {
      var des = DES.Create();
      des.Mode = CipherMode.ECB;
      des.Padding = PaddingMode.None;
      des.Key = key1;
      var encryptor1 = des.CreateEncryptor();
      des.Key = key2;
      var decryptor = des.CreateDecryptor();
      des.Padding = PaddingMode.PKCS7;
      des.Key = key3;
      var encryptor2 = des.CreateEncryptor();
      byte[] result;
      using (var ms = new MemoryStream())
      {
        using (var cs1 = new CryptoStream(ms, encryptor1, CryptoStreamMode.Write))
        using (var cs2 = new CryptoStream(cs1, decryptor, CryptoStreamMode.Write))
        using (var cs3 = new CryptoStream(cs2, encryptor2, CryptoStreamMode.Write))
          cs3.Write(plainText, 0, plainText.Length);
        result = ms.ToArray();
      }
      return result;
    }
    public static byte[] TripleDESDecrypt(byte[] cipherText, byte[] key1, byte[] key2, byte[] key3)
    {
      var des = DES.Create();
      des.Mode = CipherMode.ECB;
      des.Padding = PaddingMode.PKCS7;
      des.Key = key3;
      var decryptor1 = des.CreateDecryptor();
      des.Padding = PaddingMode.None;
      des.Key = key2;
      var encryptor = des.CreateEncryptor();
      des.Key = key1;
      var decryptor2 = des.CreateDecryptor();
      byte[] result;
      using (var ms = new MemoryStream())
      {
        using (var cs1 = new CryptoStream(ms, decryptor1, CryptoStreamMode.Write))
        using (var cs2 = new CryptoStream(cs1, encryptor, CryptoStreamMode.Write))
        using (var cs3 = new CryptoStream(cs2, decryptor2, CryptoStreamMode.Write))
          cs3.Write(cipherText, 0, cipherText.Length);
        result = ms.ToArray();
      }
      return result;
    }
