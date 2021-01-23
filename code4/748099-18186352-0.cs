    while (xmlReader.Read())
    {
        if (xmlReader.NodeType == XmlNodeType.Element)
        {
            XmlDocument d = new XmlDocument();
            d.CreateElement().InnerText = xmlReader.ReadOuterXml();
         }
    }
