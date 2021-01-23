     private static void Serialize(string fileName, object source)
        {
            var userStore = IsolatedStorageFile.GetUserStoreForApplication();
            using (var stream = new IsolatedStorageFileStream(fileName, FileMode.Create, userStore))
            {
                XmlSerializer serializer = new XmlSerializer(source.GetType());
                serializer.Serialize(stream, source);
            }
        }
