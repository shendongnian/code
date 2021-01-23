    var store = IsolatedStorageFile.GetUserStoreForApplication();
            if (store.FileExists( filePath))
            {
                using (var stream = new IsolatedStorageFileStream( filePath, FileMode.OpenOrCreate, FileAccess.Read, store))
                {
                    var reader = new StreamReader(stream);
                    if (!reader.EndOfStream)
                    {
                        var serializer = new XmlSerializer(typeof(List<RssItem>));
                            RssItemsList= (List<RssItem>)serializer.Deserialize(reader);
                    }
                }
            }
