    string xmlString = null;
    using (StringWriter xmlOutput = new StringWriter())
    using(XmlTextWriter xmlWriter = new XmlTextWriter(xmlOutput))
    {
        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement("product");
        xmlWriter.WriteElementString("name", pName);
        xmlWriter.WriteElementString("price", pPrice);
        xmlWriter.WriteEndElement();
        xmlString = xmlOutput.ToString();
    }
