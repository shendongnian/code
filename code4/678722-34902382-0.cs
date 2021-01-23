    private byte[] saltBytes = ASCIIEncoding.ASCII.GetBytes(salt);
    public string Encrypt<T>(string value, string password) where T: SymmetricAlgorithm, new() {
      byte[] valueBytes = UTF8Encoding.UTF8.GetBytes(value);
      byte[] encrypted = null;
      using (T cipher = new T()) {
        var db = new Rfc2898DeriveBytes(password, saltBytes);
        db.IterationCount = iterationsConst;
        var key = db.GetBytes(keySizeConst / 8);
        cipher.Mode = CipherMode.CBC;
        using (ICryptoTransform encryptor = cipher.CreateEncryptor(key, vectorBytes)) {
          using (MemoryStream ms = new MemoryStream()) {
            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write)) {
              cs.Write(valueBytes, 0, valueBytes.Length);
              cs.FlushFinalBlock();
              encrypted = ms.ToArray();
            }
          }
        }
        cipher.Clear();
      }
      return Convert.ToBase64String(encrypted);
    }
