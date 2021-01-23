    var xdoc = XDocument.Load("http://blogs.technet.com/b/markrussinovich/atom.aspx");
    XNamespace ns = XNamespace.Get("http://www.w3.org/2005/Atom");
    var info = xdoc.Root
                .Descendants(ns+"entry")
                .Select(n =>
                    new
                    {
                        Title = n.Element(ns+"title").Value,
                        Time = DateTime.Parse(n.Element(ns+"published").Value),
                    }).ToList();
