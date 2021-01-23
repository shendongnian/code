    public static T LoadFromXML<T>(this Object A, string FileName) where T : class
    {
        if (File.Exists(FileName))
        {
            using (var textReader = new StreamReader(FileName))
            {
                var deserializer = new XmlSerializer(A.GetType());
                return (T)(deserializer.Deserialize(textReader));
            }
        }
        return default(T);
    }
