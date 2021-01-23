    var xmlReaderSettings = new XmlReaderSettings
    {
        XmlResolver = new XmlXapResolver()
    };
    using (var xmlReader = XmlReader.Create("WMAppManifest.xml", xmlReaderSettings))
    {
        xmlReader.ReadToDescendant("App");
        var AppName = xmlReader.GetAttribute("Title");
        var AppVersion = xmlReader.GetAttribute("Version");
    }
