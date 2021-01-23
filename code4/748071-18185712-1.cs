    var activities = from a in xdoc.Descendants("activity")
                     let u = a.Element("user")
                     let so = a.Element("storageObject")
                     select new {
                         Date = (DateTime)a.Attribute("date"),
                         Name = (string)a.Attribute("name"),
                         User = new {
                              Id = (string)u.Attribute("id"),
                              Name = (string)u.Attribute("name")
                         },
                         Storage = new {
                              Client = (string)so.Element("Client")
                         }
                         //...
                     };
