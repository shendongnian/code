    XDocument xDoc = XDocument.Load(new StringReader(xml));
    XNamespace atom = XNamespace.Get("http://www.w3.org/2005/Atom");
    XNamespace digg = XNamespace.Get("http://digg.com/docs/diggrss/");
    XNamespace media = XNamespace.Get("http://search.yahoo.com/mrss/");
    var items = xDoc
                .Descendants(atom + "entry")
                .Select(x => new
                {
                    Title = x.Element(atom + "title").Value,
                    Link = x.Element(atom + "link").Attribute("href").Value,
                    Category = x.Element(digg+"category").Value.Trim(),
                    Thumbnail = x.Element(media+"thumbnail").Attribute("url").Value
                })
                .ToArray();
