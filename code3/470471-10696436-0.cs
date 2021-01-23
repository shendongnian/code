        public static void Serialize<T>(T obj, string fileName)
        {   
         try
          {
            var store = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream stream = store.OpenFile(fileName, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (XmlWriter xmlWriter = XmlWriter.Create(stream, writerSettings))
            {
                serializer.Serialize(xmlWriter, obj);
            }
        stream.Close();
       }
       catch (Exception ex)
       {
          throw ex;
       }
      }
        public static T DeSerialize<T>(string fileName)
        {
          try
          {
             var store = IsolatedStorageFile.GetUserStoreForApplication();
             IsolatedStorageFileStream stream = store.OpenFile(fileName, FileMode.Open);
             XmlSerializer serializer = new XmlSerializer(typeof(T));
             return (T)serializer.Deserialize(stream);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        } 
