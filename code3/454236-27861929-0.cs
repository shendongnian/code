    public string TestEncrypt(string key, string dataTest)
    {
       var keyBytes = Encoding.UTF8.GetBytes(key);
       HMACSHA1 hashAlgorithm = new HMACSHA1(keyBytes);            
       byte[] dataBuffer = Encoding.UTF8.GetBytes(dataTest);
       byte[] hashBytes = hashAlgorithm.ComputeHash(dataBuffer);
       return Convert.ToBase64String(hashBytes);
    }
