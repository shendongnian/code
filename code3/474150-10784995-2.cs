    public static byte[] TripleDESEncryptFramework(byte[] plainText, byte[] key)
    {
      var tdes = TripleDES.Create();
      tdes.Mode = CipherMode.ECB;
      tdes.Padding = PaddingMode.PKCS7;
      tdes.Key = key;
      var encryptor = tdes.CreateEncryptor();
      byte[] result;
      using (var ms = new MemoryStream())
      {
        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
          cs.Write(plainText, 0, plainText.Length);
        result = ms.ToArray();
      }
      return result;
    }
