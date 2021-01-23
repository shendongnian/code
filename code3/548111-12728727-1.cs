    XmlNamespaceManager nsm = new XmlNamespaceManager(xmlDoc.NameTable);
    nsm.AddNamespace("s", "http://site.ddf.com");
    XmlNodeList elemList = xmlDoc.SelectNodes("//s:crewMembers/s:item", nsm);
    foreach (XmlNode node in elemList)
    {
        Debug.WriteLine(node.SelectSingleNode("s:employeeId", nsm).InnerText);
        Debug.WriteLine(node.SelectSingleNode("s:isDepositor", nsm).InnerText);
        Debug.WriteLine(node.SelectSingleNode("s:isTransmitter", nsm).InnerText);
    }
