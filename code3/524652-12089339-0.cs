    string urlStr = "https://xyz.com/sample.zip";
    
     using (WebClient client = new WebClient())
      {
       byte []bytes=client.DownloadData(urlStr);
       using (MemoryStream ms = new MemoryStream(bytes))
       {
        using (ZipFile zip = ZipFile.Read(ms))
        {
         zip.ExtractAll(@"C:\csnet");
        }
       }
     }
