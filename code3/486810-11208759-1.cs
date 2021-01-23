    public static object DeserializeObject(string fileName, Type objectType)
        {
            using (IsolatedStorageFile appStorage = IsolatedStorageFile.GetUserStoreForApplication())
            using (IsolatedStorageFileStream fileStream = appStorage.OpenFile(fileName, FileMode.Open, FileAccess.Read))
            using (TextReader xmlReader = new StreamReader(fileStream))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(objectType);
                return xmlSerializer.Deserialize(xmlReader);
            }
        }
        public static void SerializeObject(string fileName, object target, Type objectType)
        {
            using (IsolatedStorageFile appStorage = IsolatedStorageFile.GetUserStoreForApplication())
            using (IsolatedStorageFileStream fileStream = appStorage.OpenFile(fileName, FileMode.Create, FileAccess.Write))
            using (TextWriter xmlWriter = new StreamWriter(fileStream))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(objectType);
                xmlSerializer.Serialize(xmlWriter, target);
            }
        }
