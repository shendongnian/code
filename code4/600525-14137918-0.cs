    XmlDocument xmlDoc = new XmlDocument();
    XmlNode rootNode = xmlDoc.CreateElement("Info");
    xmlDoc.AppendChild(rootNode);
    XmlNode userNode = xmlDoc.CreateElement("Username");
    userNode.InnerText = Username.Text;
    rootNode.AppendChild(userNode);
    xmlDoc.Save(gameFolder + Username.Text + ".sav");
