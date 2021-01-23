    string xmlNamespace = String.Empty;
    XmlNamespaceManager nsmgr;
    XmlNodeList nodeInfo = FABRequestXML.GetElementsByTagName("RootNodeName");
    xmlNamespace = Convert.ToString(nodeInfo[0].Attributes["xmlns"].Value);
    nsmgr = new XmlNamespaceManager(MyXml.NameTable);
    nsmgr.AddNamespace("AB", xmlNamespace);
    
    XmlNode myNode = MyXml.DocumentElement.SelectSingleNode("AB:NodeName", nsmgr);
