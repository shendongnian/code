    Dictionary<string, Ultimate> ultimateCollection = new Dictionary<string, Ultimate>();
    foreach(XmlNode node in xmlDocument1.SelectNodes("/DATA1"))
    {
        Ultimate ultimate = new Ultimate(node);
        ultimateCollection.Add(ultimate.Name, ultimate);
    }
   
    foreach(XmlNode node in root.ChildNodes)
    {
        Ultimate ultimate;
        if (ultimateCollection.TryGetValue(node.Name, out ultimate))
            ultimate.Values = node.InnerText;
    }
    
