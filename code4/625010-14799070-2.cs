    XmlNode prof = xmldoc.CreateNode(XmlNodeType.Element, "profesor", strNamespace);
    XmlNode ime = xmldoc.CreateNode(XmlNodeType.Element, "ime", strNamespace);
    ime.InnerText = name;
    prof.AppendChild(ime);
    
    XmlNode prezime = xmldoc.CreateNode(XmlNodeType.Element, "prezime", strNamespace);
    prezime.InnerText = surname;
    prof.AppendChild(prezime);
    
    root.AppendChild(prof);
