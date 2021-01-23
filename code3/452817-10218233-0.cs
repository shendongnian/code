    XmlWriterSettings settings = new XmlWriterSettings();
    settings.OmitXmlDeclaration = true;
    
    MemoryStream ms = new MemoryStream();
    XmlWriter writer = XmlWriter.Create(ms, settings);
    
    XmlSerializerNamespaces names = new XmlSerializerNamespaces();
    names.Add("", "");
    
    XmlSerializer cs = new XmlSerializer(typeof(Cat));
    
    cs.Serialize(writer, new Cat { Lives = 9 }, names);
    
    ms.Flush();
    ms.Seek(0, SeekOrigin.Begin);
    StreamReader sr = new StreamReader(ms);
    var xml = sr.ReadToEnd();
