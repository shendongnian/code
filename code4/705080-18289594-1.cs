    try
    {
        doc = XDocument.Load(spath, LoadOptions.SetBaseUri);
        foreach(String propertyData in dataList)
        {
            XElement root = new XElement(ElementName);
            root.Add(new XElement("property1", propertyData));
            doc.Element(MainElement).Add(root);
        }
        doc.Save(spath);
    }
    catch (Exception)
    {
    }
