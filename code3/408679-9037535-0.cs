    string GetAppath(string xmlString, string picPath)
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml(xmlString);
        XmlNodeList xList = xDoc.SelectNodes("/picture");
        foreach (XmlNode xNode in xList)
        {
            if (xNode["path"].InnerText == picPath)
            {
                return xNode["appath"].InnerText;
            }
        }
    }
