    string hash;
    using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create()) {
      hash = BitConverter.ToString(
        md5.ComputeHash(Encoding.UTF8.GetBytes(theString))
      ).Replace("-", String.Empty);
    }
    
    Console.WriteLine(hash);
