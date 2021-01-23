    public static String Serialize(object obj)
    {
        StringBuilder builder = new StringBuilder();
        XmlSerializer serializer = new XmlSerializer(typeof(theirObj));
        using (XmlWriter writer = XmlWriter.Create(builder, new XmlWriterSettings() { OmitXmlDeclaration = true }))
            xmlSerializer.Serialize(writer, obj);
        return builder.ToString();
    }
