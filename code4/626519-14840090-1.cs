    XmlDocument xml = new XmlDocument();
    XmlElement root = xml.CreateElement("root");
    xml.AppendChild(root);
    XmlComment comment = xml.CreateComment("Comment");
    root.AppendChild(comment);
    XmlWriterSettings settings = new XmlWriterSettings
    {
        Encoding           = Encoding.UTF8,
        ConformanceLevel   = ConformanceLevel.Document,
        OmitXmlDeclaration = false,
        CloseOutput        = true,
        Indent             = true,
        IndentChars        = "  ",
        NewLineHandling    = NewLineHandling.Replace
    };
    
    using (StreamWriter sw = File.CreateText("output.xml"))
    using (XmlWriter writer = XmlWriter.Create(sw, settings))
    {
        xml.WriteContentTo(writer);
        writer.Close();
    }
    
    string document = File.ReadAllText("output.xml");
