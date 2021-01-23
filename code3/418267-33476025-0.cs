    try
    {
        XmlSerializer ser;
        XmlSerializerNamespaces SerializeObject = new mlSerializerNamespaces();
        ser = new XmlSerializer((ObjType));
        MemoryStream memStream;
        memStream = new MemoryStream();
        XmlTextWriter xmlWriter;
        xmlWriter = new XmlTextWriter(memStream, Encoding.UTF8);
        xmlWriter.Namespaces = true;
        XmlQualifiedName[] qualiArrayXML = SerializeObject.ToArray();
        ser.Serialize(xmlWriter, Obj);
        xmlWriter.Close();
        memStream.Close();
        string xml;
        xml = Encoding.UTF8.GetString(memStream.GetBuffer());
        xml = xml.Substring(xml.IndexOf(Convert.ToChar(60)));
        xml = xml.Substring(0, (xml.LastIndexOf(Convert.ToChar(62)) + 1));
        return xml;
    }
    catch (Exception ex)
    { return string.Empty; }
