    using(Stream input = File.OpenRead(strZipFilePath)){
       /// .NET 4.0
       input.CopyTo(Response.OutputStream);
    
       /// .NET 2.0
       byte[] buffer = new byte[4096];
       int count = input.Read(buffer,0,buffer.Length);
       while(count > 0){
          Response.OutputStream.Write(buffer,0,count);
          count = input.Read(buffer,0,buffer.Length);
       }
    }
    
    File.Delete(strZipFilePath);
