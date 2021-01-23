    using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(saveToPath, FileMode.Create))    
    {    
      Copy(stream, fileStream);     
    } 
    public void Copy(Stream source, Stream target) 
    {
      byte[] buffer = new byte[0x10000];
      int bytes;
      try 
      {
        while ((bytes = source.Read(buffer, 0, buffer.Length)) > 0) 
        {
          target.Write(buffer, 0, bytes);
        }
      }
    
      finally 
      {
        target.Flush();
        // Or target.Close(); if you're done here already.
      }
    }
