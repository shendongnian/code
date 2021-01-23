    string resultFromBytes = UTF8Encoding.UTF8.GetString(result);
    var nt = new NameTable();
    var nsmgr = new XmlNamespaceManager(nt);
    nsmgr.AddNamespace(String.Empty, "urn:samples"); //default namespace
    nsmgr.AddNamespace("xsi", "urn:samples2"); // xsi fix
    var context = new XmlParserContext(nt, nsmgr,null,  XmlSpace.None);
    var settings = new XmlReaderSettings();
    settings.ConformanceLevel = ConformanceLevel.Document;
            
    var xrdr= XmlReader.Create(new StringReader(xml), settings, context);
    return XDocument.Load(xrdr).Root;
