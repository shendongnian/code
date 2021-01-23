    var r = (from c in xdoc.Element("countries")
                           .Elements("country")
             select new Country
             {
                 ID = c.Attribute("ID").Value,
                 Ideas = (from i in c.Elements("idea")
                          select new Idea
                          {
                              Text = i.Attribute("ID").Value, 
                              Value = i.Value
                          }).ToList()
             }).ToList();
