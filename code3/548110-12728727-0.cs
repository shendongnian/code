    XmlNodeList elemList = xmlDoc.SelectNodes("//crewMembers/item");
    foreach (XmlNode node in elemList)
    {
        Debug.WriteLine(node.SelectNode("employeeId").InnerText);
        Debug.WriteLine(node.SelectNode("isDepositor").InnerText);
        Debug.WriteLine(node.SelectNode("isTransmitter").InnerText);
    }
