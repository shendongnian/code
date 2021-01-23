    XNamespace df = XmlHouseResults.Root.Name.Namespace;
    
    foreach (XElement house in XmlHouseResults.Descendants("df" + "House"))
    {
      MessageBox.Show((string)house.Element("df" + "house_id"));
    }
