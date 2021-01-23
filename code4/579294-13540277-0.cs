    XDocument xDocument = new XDocument();
    XElement rootNode = new XElement(typeof(Notes).Name);
    foreach (var property in typeof(Notes).GetProperties())
    {
       if (property.GetValue(a, null) == null)
       {
           property.SetValue(a, string.Empty, null);
       }
       XElement childNode = new XElement(property.Name, property.GetValue(a, null));
       rootNode.Add(childNode);
    }
    xDocument.Add(rootNode);
    XmlWriterSettings xws = new XmlWriterSettings() { Indent=true };
    using (XmlWriter writer = XmlWriter.Create("D:\\Sample.xml", xws))
    {
        xDocument.Save(writer);
    }
