    while (true)
    {
        xmlDocument_.Schemas = new XmlSchemaSet();
        using (XmlReader xmlReader = XmlReader.Create("schema.xsd", xmlReaderSettings))
        {
            xmlDocument_.Schemas.Add(XmlSchema.Read(xmlReader, null));
        }
        xmlDocument_.Validate(null);
    }
