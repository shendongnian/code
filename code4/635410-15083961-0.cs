    //Create XmlDocument
    XmlDocument xmlDoc = new XmlDocument();
    
    //Create the root element
    XmlNode outputsElement = xmlDoc.CreateElement("outputs");
    
    //Create the child element
    XmlElement Element = xmlDoc.CreateElement("output");
    
    //Create "name" Attribute
    XmlAttribute nameAtt = xmldoc.CreateAttribute("name");
    Element.Attributes.Append(nameAtt);
    
    //Create "value" Attribute
    XmlAttribute valueAtt = xmldoc.CreateAttribute("value");
    Element.Attributes.Append(valueAtt);
    
    //Create "type" Attribute
    XmlAttribute typeAtt = xmldoc.CreateAttribute("type");
    Element.Attributes.Append(typeAtt);
    
    //Append child element into root element
    outputsElement.AppendChild(Element);
