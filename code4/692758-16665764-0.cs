    var xDoc = XDocument.Load("http://search.twitter.com/search.atom?q=test&show-user=true&rpp=10");
    XNamespace ns = "http://www.w3.org/2005/Atom";
    XElement feeds = new XElement("feed", 
                            xDoc.Descendants(ns + "entry")
                                .Select(e=>new XElement("entry",
                                                    new XElement("id", e.Element(ns + "id").Value), 
                                                    new XElement("author",e.Element(ns + "author").Element(ns + "name").Value),
                                                    new XElement("created_time",e.Element(ns + "published").Value)
                                            )
                                )
                    );
    string xmlstr = feeds.ToString();
