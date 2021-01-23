    public String convertResultToXML(CResultObject[] state) 
    { 
      using(var stream = new MemoryStream)    
      { 
         // get serialise object 
        XmlSerializer serializer = new XmlSerializer(typeof(CResultObject[])); 
        serializer.Serialize(stream, state); // read object 
        int count = (int)stream.Length; // saves object in memory stream 
        byte[] arr = new byte[count]; 
        stream.Seek(0, SeekOrigin.Begin); 
        // copy stream contents in byte array 
        stream.Read(arr, 0, count); 
        UnicodeEncoding utf = new UnicodeEncoding(); // convert byte array to string 
        return utf.GetString(arr).Trim(); 
      } 
    } 
