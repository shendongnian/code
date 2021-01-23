    public static T Deserialize<T>(string xml)
    {
        var serializer = new XmlSerializer(typeof(T));
        using (TextReader reader = new StringReader(xml))
        {
            return (T)serializer.Deserialize(reader);
        }
    }
    var obj = Deserialize<ErrorNotification>(xml);
