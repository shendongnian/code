    var header = xDoc.Root.Element("Header");
    var footer = xDoc.Root.Element("Footer");
    var contents = xDoc.Root.Elements("Content")
    
    var newXDocs = contents.Select((c, i) => new { c, i })
                           .GroupBy(x => x.i / ordersPerFile)
                           .Select(x => new XDocument(
                                           new XElement("Root",
                                               header,
                                               x.Select(y => y.c),
                                               footer)))
                           .ToList();
