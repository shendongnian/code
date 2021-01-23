    XNamespace ns = "http://purl.org/rss/1.0/";
    XNamespace dc = "http://purl.org/dc/elements/1.1/";
    var items = from item in xdoc.Descendants(ns + "item")
                select new {
                    Title = (string)item.Element(ns + "title"),
                    Description = (string)item.Element(ns + "description"),
                    Link = (string)item.Element(ns + "link"),
                    PubDate = (string)item.Element(dc + "date") // date in dc
                };
