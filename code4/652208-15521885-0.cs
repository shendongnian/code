        var queryKnowledge = (from item in xDoc.Element("Knowledge").Elements("Group").Elements("Item")
                              select new
                              {
                                  Group = (string)item.Parent.Attribute("name"),
                                  Name = (string)item.Attribute("name"),
                                  Level = (string)item.Attribute("level")
                              }).AsQueryable();
