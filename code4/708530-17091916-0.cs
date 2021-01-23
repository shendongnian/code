    public static string Encrypt(string data)
    {
        using (var des = new TripleDESCryptoServiceProvider { Mode = CipherMode.ECB, Key = GetKey("a1!B78s!5(j$S1c%"), Padding = PaddingMode.PKCS7 })
        using (var desEncrypt = des.CreateEncryptor())
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            return Convert.ToBase64String(desEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));
        }
    }
    public static string Decrypt(string data)
    {
        using (var des = new TripleDESCryptoServiceProvider { Mode = CipherMode.ECB, Key = GetKey("a1!B78s!5(j$S1c%"), Padding = PaddingMode.PKCS7 })
        using (var desEncrypt = des.CreateDecryptor())
        {
            var buffer = Convert.FromBase64String(data.Replace(" ", "+"));
            return Encoding.UTF8.GetString(desEncrypt.TransformFinalBlock(buffer, 0, buffer.Length));
        }
    }
