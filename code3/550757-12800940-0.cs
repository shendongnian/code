    XmlDocument objXmlDoc = new XmlDocument();
    XmlNodeList objXmlNodeList;
    objXmlDoc.Load(sFilePath);
    objXmlNodeList = objXmlDoc.SelectNodes("//Word");
    string s = string.Empty;
    XmlNodeList wordNodes = objXmlNodeList[0].ChildNodes;
    foreach (XmlNode characterNode in wordNodes)
    {
       s = s + characterNode.InnerText;
    }
