    public static ObjectArray Deserialize(string xml, Type type)
    {
        var s = new XmlSerializer(typeof(ObjectArray),
            new Type[] { type });
        var o = (ObjectArray)s.Deserialize(new StringReader(xml));
        return o;
    }
