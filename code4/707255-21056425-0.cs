    /// <summary>
    /// Uploads the specified file to a SharePoint site
    /// </summary>
    /// <param name="url">site url</param>
    /// <param name="creds">Credentials</param>
    /// <param name="listTitle">List Title</param>
    /// <param name="fileName">File Name</param>
    private static void UploadFile(string url, ICredentials creds, string listTitle,string fileName)
    {
          using (var clientContext = new ClientContext(url))
          {
               clientContext.Credentials = creds;
    
               using (var fs = new FileStream(fileName, FileMode.Open))
               {
                   var fi = new FileInfo(fileName);
                   var list = clientContext.Web.Lists.GetByTitle(listTitle);
                   clientContext.Load(list.RootFolder);
                   clientContext.ExecuteQuery();
                   var fileUrl = String.Format("{0}/{1}", list.RootFolder.ServerRelativeUrl, fi.Name);
    
                   Microsoft.SharePoint.Client.File.SaveBinaryDirect(clientContext, fileUrl, fs, true);
                }
           }
      }
