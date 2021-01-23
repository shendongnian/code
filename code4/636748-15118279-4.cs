    public static ObjectArray Deserialize(string xml, Type[] types)
    {
        var s = new XmlSerializer(typeof(ObjectArray), types);
        var o = (ObjectArray)s.Deserialize(new StringReader(xml));
        return o;
    }
