    XDocument doc = XDocument.Load("atom.xml");
    XNamespace ns = "http://www.w3.org/2005/Atom";
    var entries = doc.Root
                     .Elements(ns + "entry")
                     .Select(item => new Item
                     {
                          FeedType = FeedType.Atom,
                          Content = (string) item.Element(ns + "content"),
                          Link = (string) item.Element(ns + "link").Attribute("href"),
                          PublishDate = (DateTime) item.Element(ns + "published"),
                          Title = (string) item.Element(ns + "title")
                      };
