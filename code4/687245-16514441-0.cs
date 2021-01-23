    private async Task DownloadFileAsync(DocumentObject doc)
    {
      try
      {
        using (WebClient webClient = new WebClient())
        {
          string downloadToDirectory = @Resources.defaultDirectory + value.docName;
          webClient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
          await webClient.DownloadFileTaskAsync(new Uri(value.docUrl), @downloadToDirectory);
          //Add them to the local
          Context.listOfLocalDirectories.Add(downloadToDirectory);
        }         
      }
      catch (Exception)
      {
        Errors.printError("Failed to download File: " + value.docName);
      }
    }
    private async Task DownloadMultipleFilesAsync(List<DocumentObject> doclist)
    {
      await Task.WhenAll(doclist.Select(doc => DownloadFileAsync(doc)));
    }
