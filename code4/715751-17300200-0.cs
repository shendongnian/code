    var header = doc.Root.Element("Header");
    var footer = doc.Root.Element("Footer");
    var contents = doc.Root.Elements("Contents");
    var newDocs = contents.Batch(ordersPerFile)
                          .Select(middle => new XDocument(
                                     new XElement("Root", header, middle, footer)))
                          .ToList();
