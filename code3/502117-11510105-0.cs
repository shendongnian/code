    UnicodeEncoding UE = new UnicodeEncoding();
    byte[] bfr;
    byte[] pwdBits = UE.GetBytes(plainText);
    byte[] result;
    int extends = (1 + (pwdBits.Length / 16)) * 16;
    bfr = new byte[extends];
    pwdBits.CopyTo(bfr, 0);
    using (MemoryStream msCrypt = new MemoryStream())
    {
        RijndaelManaged RMCrypto = new RijndaelManaged();
        RMCrypto.Padding = PaddingMode.PKCS7;
        using (ICryptoTransform encriptor = RMCrypto.CreateEncryptor(Key, IV))
        {
             using (CryptoStream cs = new CryptoStream(msCrypt, encriptor, CryptoStreamMode.Write))
             {
                  cs.Write(bfr, 0, bfr.Length);
                  cs.FlushFinalBlock();
                  result = msCrypt.ToArray();
                  cs.Close();
             }
             msCrypt.Close();
        }
    }
    return result;
