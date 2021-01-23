    System.Text.UTF8Encoding text = new System.Text.UTF8Encoding();
    System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();                
    Convert2.ToBase16(md5.ComputeHash(text.GetBytes(encPassString + sess)));
    
    
    class Convert2
    {
       public static string ToBase16(byte[] input)
       {
          return string.Concat((from x in input select x.ToString("x2")).ToArray());
       }
    }
