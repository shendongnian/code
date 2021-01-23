    public static string Serialize(object obj)
    {
        var builder = new StringBuilder();
        var xmlSerializer = new XmlSerializer(obj.GetType());
        using (XmlWriter writer = XmlWriter.Create(builder,
            new XmlWriterSettings() { OmitXmlDeclaration = true }))
        {
            xmlSerializer.Serialize(writer, obj);
        }
        return builder.ToString();
    }
