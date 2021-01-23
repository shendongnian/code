    public static void SaveAsXML(Object A, string FileName)
    {
        var serializer = new XmlSerializer(A.GetType());
        using (var textWriter = new StreamWriter(FileName))
        {
            serializer.Serialize(textWriter, A);
            textWriter.Close();
        }
    }
    public static T LoadFromXML<T>(string FileName) where T : class
    {
        if (File.Exists(FileName))
        {
            using (var textReader = new StreamReader(FileName))
            {
                var deserializer = new XmlSerializer(typeof(T));
                return (T)(deserializer.Deserialize(textReader));
            }
        }
        return default(T);
    }
