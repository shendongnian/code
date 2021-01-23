    using (XmlReader reader = xmlCommand.ExecuteXmlReader())
    {
        XmlDocument dom = new XmlDocument();
        dom.Load(reader);
        var settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.OmitXmlDeclaration = true;
        using (var writer = XmlTextWriter.Create("file2.xml", settings))
        {
            dom.WriteContentTo(writer);
        }
    }
