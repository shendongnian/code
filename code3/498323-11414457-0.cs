    public T DeSerialize<T>(string serializedObject)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using StringReader reader = new StringReader(serializedObject)
        {
            return (T)serializer.Deserialize(reader);
        }
    }
