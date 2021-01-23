    private async Task ReadFileInfo(string folderId)
    {
       LiveOperationResult operationResultFile =
       await client.GetAsync(folderId + "/files");    
       dynamic resultFile = operationResultFile.Result;
       IDictionary<string, object> fileData = (IDictionary<string, object>)resultFile;
       List<object> files = (List<object>)fileData["data"];
       foreach (object item in files)
       {
          IDictionary<string, object> file = (IDictionary<string, object>)item; 
          if (file["name"].ToString() == "ocha.txt")
          {
             LiveDownloadOperationResult DLFile =
                 await client.BackgroundDownloadAsync(file["source"].ToString());  
             using (var stream = await DLFile.GetRandomAccessStreamAsync())
             {
                using (var readStream = stream.AsStreamForRead())
                {
                   using (StreamReader streamReader = new StreamReader(readStream))
                   {
                      string content = streamReader.ReadToEnd();
                      XmlDocument doc = new XmlDocument();
                      doc.LoadXml(content); 
                      VM.importVehicles(content); 
                      break;
                   }
                }
             }
          }
       }
    }
