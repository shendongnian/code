    var xml = string.Format(@"<root>{0}</root>", Resource1.String1);
    var doc = XDocument.Parse(xml);
    // process document
    using (var file = File.CreateText(@"file.xml"))
    {
        foreach (XElement nodes in doc.Root.Elements())
        {
            file.Write(nodes);
        }
    }
