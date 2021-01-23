    var nsm = new XmlNamespaceManager(xmlDoc.NameTable);
    nsm.AddNamespace("s", "http://site.ddf.com");
    var elemList = xmlDoc.SelectNodes("//s:crewMembers/s:item", nsm);
    foreach (var node in elemList)
    {
        Debug.WriteLine(node.SelectSingleNode("s:employeeId", nsm).InnerText);
        Debug.WriteLine(node.SelectSingleNode("s:isDepositor", nsm).InnerText);
        Debug.WriteLine(node.SelectSingleNode("s:isTransmitter", nsm).InnerText);
    }
