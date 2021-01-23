    public string MD5_Encrypt(string EncryptString)
    {
      string strReturn = string.Empty;
      ASCIIEncoding ASCIenc = new System.Text.ASCIIEncoding();
      byte[] InputString = ASCIenc.GetBytes(EncryptString);
      System.Security.Cryptography.MD5CryptoServiceProvider MD5Hash = new System.Security.Cryptography.MD5CryptoServiceProvider();
      byte[] ByteHash = MD5Hash.ComputeHash(InputString);
      foreach (byte b in ByteHash)
      {
        strReturn += b.ToString("x2");
      }
      return strReturn.ToString();
    }
