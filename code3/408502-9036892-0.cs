    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ConformanceLevel = ConformanceLevel.Fragment;
    
    using (XmlReader reader = XmlReader.Create("tracelog.xml", settings))
    {
        while (reader.Read())
        {
            // Process each node of the fragment,
            // possibly using reader.ReadSubtree()
        }
    }
