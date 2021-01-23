    public string XmlSerialize<T>(T entity) where T : class
    {
        // removes version
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.OmitXmlDeclaration = true;
        XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
        StringWriter sw = new StringWriter();
        using (XmlWriter writer = XmlWriter.Create(sw, settings))
        {
            // removes namespace
            var xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);
            xsSubmit.Serialize(writer, entity, xmlns);
            return sw.ToString(); // Your XML
        }
    }
