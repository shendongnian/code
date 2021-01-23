    XmlDocument doc = new XmlDocument();
    doc.Load("myxml.xml");
    XmlNode root = doc.DocumentElement;
    XmlNodeList nodeList = root.SelectNodes("//Event");
    
    for (int i = 0; i < nodeList.Count; i++)
    {
        Console.WriteLine(string.Concat("row: ", i, " InnerText: ", nodeList[i].InnerText));
    }
