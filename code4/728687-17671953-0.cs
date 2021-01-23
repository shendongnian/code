    var writerSettings = new XmlWriterSettings();
    writerSettings.OmitXmlDeclaration = true;
    using (var buffer = new StringWriter())
    using (var writer = XmlWriter.Create(buffer, writerSettings))
    {
        xml.Save(writer);
        writer.Flush();
        string result = buffer.ToString();
    }
