    if (page != null)
    {
        // add to Hotspots element
        page.Element("Hotspots")
            .Add(new XElement("Hotspot",
                     new XElement("X", x),
                     new XElement("Y", y),
                     new XElement("Shape", "Circle"),
                     new XElement("TargetId", nNodeID)));
        xdoc.Save("Test.xml");
    }
