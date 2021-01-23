    XDocument xml = XDocument.Load("http://blogs.technet.com/b/markrussinovich/atom.aspx");
    XNamespace ns = XNamespace.Get("http://www.w3.org/2005/Atom");
    var xmlFeed = from post in xml.Descendants(ns + "entry")
                  select new
                  {
                       Title = post.Element(ns + "title").Value,
                       Time = DateTime.Parse(post.Element(ns + "published").Value)
                  };
