    MemoryStream w = new MemoryStream();
    XmlTextWriter writer = new XmlTextWriter(w, Encoding.Unicode);
    
    XmlDocument document = new XmlDocument();
    document.LoadXml(xmlString);
    writer.Formatting = Formatting.Indented;
    document.WriteContentTo(writer);
    
    writer.Flush();
    w.Seek(0L, SeekOrigin.Begin);
    
    StreamReader reader = new StreamReader(w);
    return reader.ReadToEnd();
