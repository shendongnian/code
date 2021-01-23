    void SaveToFile(String fileName, Parametres obj)
    {
       ObjectXmlSerializer oxs = new ObjectXmlSerializer();
       Byte[] bObj = oxs.Serialize(obj);
       Byte[] bEncObj = CryptoSerivces.AesEncrypt(bObj, SomeKey, SomeIV);
    
       using (FileStream fs = File.Open(filename, FileMode.OpenOrCreate))
       {
          fs.Write(bEncObj, 0, bEncObj.Length);
       }
    }
