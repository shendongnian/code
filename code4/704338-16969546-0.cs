    public static byte[] AES_Encrypt(byte[] data, string[] aes_key)
    {
        var aes = new RijndaelManaged();
        aes.KeySize = 256;
        aes.BlockSize = 256;
        aes.Padding = PaddingMode.PKCS7;
    
        aes.Key = Encoding.Default.GetBytes(aes_key[0]);
        aes.IV = Encoding.Default.GetBytes(aes_key[1]);
    
        var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
    
        using(MemoryStream ms = new MemoryStream())
        {
          using(CryptoStream cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
            cs.Write(data, 0, data.Length);
    
          return ms.ToArray();
        }
    }
    
    public static byte[] AES_Decrypt(byte[] data, string[] aes_key)
    {
        RijndaelManaged aes = new RijndaelManaged();
        aes.KeySize = 256;
        aes.BlockSize = 256;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
    
        aes.Key = Encoding.Default.GetBytes(aes_key[0]);
        aes.IV = Encoding.Default.GetBytes(aes_key[1]);
    
        var decrypt = aes.CreateDecryptor();
    
        using(MemoryStream ms = new MemoryStream())
        {
          using(CryptoStream cs = new CryptoStream(ms, decrypt, CryptoStreamMode.Write))
            cs.Write(data, 0, data.Length);
    
          return ms.ToArray();
        }
    }
