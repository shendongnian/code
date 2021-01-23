    string str = "<Root><Run Text='hello world' /><Run Text='hello world2' /></Root>";
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(str);
    XmlNodeList nodes = doc.SelectNodes("Root/Run");
    foreach (XmlNode node in nodes)
    {
        XmlAttribute attr = node.Attributes["Text"];
        node.InnerText = attr.Value.ToString();
        node.Attributes.Remove(attr);                
    }
    str = doc.InnerXml;
