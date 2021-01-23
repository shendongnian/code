    var xml = SerializeToXML(person);
    static string SerializeToXML<T>(T obj)
    {
        StringWriter s = new StringWriter();
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(s, obj);
        return s.ToString();
    }
