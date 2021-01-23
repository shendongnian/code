    //Store the namespace for xsi to save retyping it.
    string xsi = "http://www.w3.org/2001/XMLSchema-instance";
    XmlDocument doc = new XmlDocument();
    XmlSchema schema = new XmlSchema();
    schema.Namespaces.Add("xsi", xsi);
    doc.Schemas.Add(schema);
    XmlNode docRoot = doc.CreateElement("eConnect");
    doc.AppendChild(docRoot);
    XmlNode eConnectProcessInfo = doc.CreateElement("eConnectProcessInfo");
    XmlAttribute xsiNil = doc.CreateAttribute("nil",xsi);
    xsiNil.Value = "true";
    eConnectProcessInfo.Attributes.Append(xsiNil);
    docRoot.AppendChild(eConnectProcessInfo);
