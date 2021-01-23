    public static T Read<T>(string fileName)
    {
        var reader = new XmlSerializer(typeof(T));
        using (StreamReader file = new StreamReader(fileName))
        {
            return (T)reader.Deserialize(file);
        }
    }
