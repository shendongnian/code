    var writerSettings = new XmlWriterSettings();
    writerSettings.OmitXmlDeclaration = true;
    using (var buffer = new StringWriter())
    using (var writer = XmlWriter.Create(buffer, writerSettings))
    {
        cubbingmessagexml.Save(writer);
        writer.Flush();
        string result = buffer.ToString();
    }
