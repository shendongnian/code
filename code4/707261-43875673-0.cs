     Uri filename = new Uri(filepath);
            string server = filename.AbsoluteUri.Replace(filename.AbsolutePath, 
             "");
            string serverrelative = filename.AbsolutePath;
    
            Microsoft.SharePoint.Client.File file = 
            this.ClientContext.Web.GetFileByServerRelativeUrl(serverrelative);
            this.ClientContext.Load(file);
            ClientResult<Stream> streamResult = file.OpenBinaryStream();
            this.ClientContext.ExecuteQuery();
            return streamResult.Value;
        
 
