    static void Main(string[] args)
    {
        XmlDataDocument Doc = new XmlDataDocument();
        XmlNodeList nodeList;
        XmlElement Element;
        XmlNode node = null;
        Doc.Load(@"UNC path of a doc.xml file");
        Element = Doc.DocumentElement;
        nodeList = Element.SelectNodes("Application");
        foreach (XmlNode n in nodeList)
        {
            if (n.Attributes[@"Name"].InnerText = @"Something")
                break;
        }
        //gsCurrentMode is one of "Production","Test","Develope"
        nodeList = node.SelectNodes("Instance");
        foreach (XmlNode n in nodeList)
        {
            if (node.Attributes["Mode"].Value = @"Production")
                //if either of these two fails, Something shuts down
                return node.Attributes["Server"].InnerText;
            else
            {
                return;
            }
        }       
    }
