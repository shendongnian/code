    XDocument xdoc = XDocument.Parse(instanceXml);
    var query = from c in xdoc.Descendatns("Computer")
                where (string)c.Attribute("type") != "HP"
                select new {
                   Name = (string)c.Attribute("Name"),
                   Type = (string)c.Attribute("type"),
                   Accessories = from a in c.Elements()
                                 select new {
                                    Type = (string)a.Attribute("type"),
                                    Model = (string)a.Attribute("model")
                                 }
                };
