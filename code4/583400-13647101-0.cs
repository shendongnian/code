    XmlDocument doc = new XmlDocument();
    doc.LoadXml(yourInputString);
    XmlNodeList colNodes = xmlSource.SelectNodes("li");
    foreach (XmlNode node in colNodes)
    {
        // ... your logic here
        // for example
        // string parentName = node.SelectSingleNode("a").InnerText;
        // string parentHref = node.SelectSingleNode("a").Attribures["href"].Value;
        // XmlNodeList children = 
        //       node.SelectSingleNode("ul").SelectNodes("li");
        // foreach (XmlNode child in children)
        // {
        //         ......
        // }
    }
