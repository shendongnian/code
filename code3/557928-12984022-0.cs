    public static XmlNodeList Scan(XmlNodeList nodeList)
    {
        List<XmlNode> toRemove = new List<XmlNode>();
        foreach (XmlNode xmlElement in nodeList)
        {
            string elementValue = xmlElement.InnerText;
            if (elementValue.Length < 6 || elementValue.Substring(0, 3) != "999")
            {
                toRemove.Add(xmlElement);
            }
        }
        foreach(XmlNode xmlElement in toRemove)
        {
            XmlNode node = xmlElement.ParentNode;
            node.RemoveChild(xmlElement);
        }
        return nodeList;
    }
