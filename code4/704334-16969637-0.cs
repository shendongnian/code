    public void saveStuff()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(@"Worlds\WorldData.xml"); //loads the file just fine
    
        XmlElement root = xmlDoc.DocumentElement;
        XmlNode node = root.SelectSingleNode("//World[@ID='002']/Name"); //node = null
        node.Value = "New Name"; //NullReferenceException was unhandled
        xmlDoc.Save(@"Worlds\example.xml");
    }
