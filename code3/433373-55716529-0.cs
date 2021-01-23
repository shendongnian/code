     public Stream GetFile(string id)
     {
          WebOperationContext.Current.OutgoingResponse.ContentType = "application/txt";
          var byt = File.ReadAllBytes("C:\\Test.txt");
          WebOperationContext.Current.OutgoingResponse.ContentLength = byt.Length;
          return new MemoryStream(byt);
     }
