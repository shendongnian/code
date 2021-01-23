    static List<String> GetLeavesText()
    {
        var result = new List<String>();
        XmlDocument document = new XmlDocument();
        document.LoadXml(...);
        var nodeList = document.SelectNodes(@"//P2[@Text='AA']//L/@Text");
        if (nodeList != null)
            foreach (XmlNode xmlNode in nodeList)
            {
                result.Add(xmlNode.InnerText);
            }
        return result;
    }
