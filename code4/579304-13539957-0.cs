        public static List<T> RetrieveListFromXml<T>(string xmlFilePath)
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            object result;
            using (var stream = new FileStream(xmlFilePath, FileMode.Open))
            {
                result = serializer.Deserialize(new FileStream(xmlFilePath, FileMode.Open));
            }
            return (List<T>)result;
        }
