     var store = IsolatedStorageFile.GetUserStoreForApplication();
         if (store.FileExists(filePath))
                {
                    store.DeleteFile(filePath);
                }
             using (var stream = new IsolatedStorageFileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, store))
             {
                var serializer = new XmlSerializer(typeof(List<RssItem>));
                serializer.Serialize(stream, RssItemsList);
             }
