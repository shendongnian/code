    var appSettingsNode = xmlDoc.DocumentElement
                                .ChildNodes
                                .Cast<XmlNode>()
                                .FirstOrDefault(x => x.Name == "appSettings");
    if(appSettingsNode == null)
        return;
        
    var commentedNodes = appSettingsNode.ChildNodes
                                        .Cast<XmlNode>()
                                        .Where(x => x.NodeType == XmlNodeType.Comment
                                                    && (x.InnerText.Contains("Number")
                                                        || x.InnerText.Contains("Class")));
    foreach(var commentedNode in commentedNodes)
    {
        var tmpDoc = new XmlDocument();
        tmpDoc.LoadXml(commentNode.InnerText);
        appSettingsNode.ReplaceChild(xmlDoc.ImportNode(tmpDoc.DocumentElement, true),
                                     commentNode);
        // Use this instead if you want to keep the commented line:
        // appSettingsNode.AppendChild(xmlDoc.ImportNode(tmpDoc.DocumentElement, true));
    }
