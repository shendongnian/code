    using (var clientContext = new ClientContext(url))
    {
       
         var list = clientContext.Web.Lists.GetByTitle(listTitle);
         var listItem = list.GetItemById(listItemId);
         clientContext.Load(list);
         clientContext.Load(listItem, i => i.File);
         clientContext.ExecuteQuery();
                   
         var fileRef = listItem.File.ServerRelativeUrl;
         var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, fileRef);
         var fileName = Path.Combine(filePath,(string)listItem.File.Name);
         using (var fileStream = System.IO.File.Create(fileName))
         {                  
              fileInfo.Stream.CopyTo(fileStream);
         }
    }
    
