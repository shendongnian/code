    var data = (List<object>)e.Result["data"];
          foreach (IDictionary<string, object> content in data)
           {                   
               var skyContent = new SkyDriveContent();
               skyContent.Name = (string)content["name"];
               ContentList.Add(skyContent);    // where ContentList is :     List<SkyDriveContent> ContentList = new List<SkyDriveContent>(); in your class                
           }
