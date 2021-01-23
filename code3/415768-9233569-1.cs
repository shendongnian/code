    public String GetEntityXml<T>(List<T> entities)
    {
        var sb = new StringBuilder();
        var settings = new XmlWriterSettings { OmitXmlDeclaration = true };
        using (XmlWriter writer = XmlWriter.Create(sb, settings))
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(typeof(T).Name + "_LIST"));
            var namespaces = new XmlSerializerNamespaces(new[] { new XmlQualifiedName("", "") });
            ser.Serialize(writer, entities, namespaces);
        }
        return sb.ToString();
    }
