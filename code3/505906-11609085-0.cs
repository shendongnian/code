    using (MemoryStream ms =  new MemoryStream())
    {
      using (StreamWriter sw = new StreamWriter(ms))
       {
         MyFileWriter.WriteToFile(someData, sw);
       }
    }
