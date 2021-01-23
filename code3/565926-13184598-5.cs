    public static T Read<T>(string fileName)
    {
        var serializer = new XmlSerializer(typeof(T));
        using (StreamReader file = new StreamReader(fileName))
        {
            return (T)serializer.Deserialize(file);
        }
    }
