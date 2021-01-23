    public void saveStuff()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(@"Worlds\WorldData.xml");
    
        XmlElement root = xmlDoc.DocumentElement;
        XmlNode node = root.SelectSingleNode("//World[@ID='002']/Name");
        node.Value = "New Name";
        xmlDoc.Save(@"Worlds\example.xml");
    }
