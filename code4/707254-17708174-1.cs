        //First construct client context, the object which will be responsible for
        //communication with SharePoint:
        var context = new ClientContext(@"http://site.absolute.url")
        //then get a hold of the list item you want to download, for example
        var list = context.Web.Lists.GetByTitle("Pipeline");
        var query = CamlQuery.CreateAllItemsQuery(10000);
        var result = list.GetItems(query);
        //note that data has not been loaded yet. In order to load the data
        //you need to tell SharePoint client what you want to download:
        context.Load(result, items=>items.Include(
            item => item["Title"],
            item => item["FileRef"]
        ));
        //now you get the data
        context.ExecuteQuery();
        //here you have list items, but not their content (files). To download file
        //you'll have to do something like this:
        var item = items.First();
        
        //get the URL of the file you want:
        var fileRef = item["FileRef"];
        //get the file contents:
        FileInformation fileInfo = File.OpenBinaryDirect(context, fileRef.ToString());
        
        using (var memory = new MemoryStream())
        {
              byte[] buffer = new byte[1024 * 64];
              int nread = 0;
              while ((nread = fileInfo.Stream.Read(buffer, 0, buffer.Length)) > 0)
              {
                  memory.Write(buffer, 0, nread);
              }
              memory.Seek(0, SeekOrigin.Begin);
              // ... here you have the contents of your file in memory, 
              // do whatever you want
        }
