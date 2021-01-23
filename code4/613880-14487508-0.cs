    var cat = (from c in xdoc.Descendants("countries")
                             .Elements("country")
              select new Idea
              {
                  Country = c.Attribute("ID").Value,
                  ListIdeas = (from i in c.Elements("idea")
                              select new ListItem 
                              {
                                  Text = i.Attribute("ID").Value , 
                                  Value = i.Value
                              }).ToList()
              }).ToList();
