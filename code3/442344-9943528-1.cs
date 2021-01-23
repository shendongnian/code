    private static byte[] GetMD5(string p)  
    {  
      using(var fs = new FileStream(p, FileMode.Open))
      {
        using(var alg = new MD5CryptoServiceProvider())
        {
          return alg.ComputeHash(fs);  
        }
      }
    }  
