    XmlDocument doc = new XmlDocument();
    doc.Load("myxml.xml");
    XmlNode root = doc.DocumentElement;
    XmlNodeList nodeList = root.SelectNodes("//Event");
    
    for (int i = 0; i < nodeList.Count; i++)
    {
        Console.WriteLine("row: {0}, InnerText: {1}, ID: {2}",i, nodeList[i].InnerText, nodeList[i].Attributes["id"].Value);
    }
