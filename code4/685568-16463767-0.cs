    void Write<T>(Stream s,T obj)
    {
        var serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(s, obj);
    }
    T Read<T>(Stream s)
    {
        var serializer = new XmlSerializer(typeof(T));
        return (T)serializer.Deserialize(s);
    }
