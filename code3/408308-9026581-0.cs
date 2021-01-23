    var xdoc = XDocument.Load(DETAILS);
    var info = xdoc
                .Descendants("BookData")
                .Select(n =>
                    new{
                        Title = n.Element("Title").Value,
                        AuthorsText = n.Element("AuthorsText").Value,
                        Summary = n.Element("Summary").Value,
                    }
                 ).ToList();
