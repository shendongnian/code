    public static void Write<T>(T objectToSerialize, string fileName)
    {
        var xmlSerializer = new XmlSerializer(objectToSerialize.GetType());
        ...
    }
