    string savedTabControl = XamlWriter.Save(originalTabControl);
    
    StringReader stringReader = new StringReader(savedTabControl);
    XmlReader xmlReader = XmlReader.Create(stringReader);
    TabControl newTabControl = (TabControl)XamlReader.Load(xmlReader);
