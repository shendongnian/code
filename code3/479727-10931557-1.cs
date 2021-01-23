    var list =
                        element.Elements(ns + "Parent")
                            .Select(compileItem => new Parent
                                                       {
                                                           Id = Convert.ToInt32(compileItem.Attribute("id").Value),
                                                           Name = compileItem.Attribute("name").Value,
                                                           Childrens = compileItem.Elements(ns + "Child")
                                                               .Select(child => new Child
                                                                                    {
                                                                                        Id = Convert.ToInt32(child.Attribute("id").Value),
                                                                                        Name = child.Attribute("name").Value,
                                                                                        Items = child.Elements(ns + "Item")
                                                                                            .Select(xe => new Item()
                                                                                                              {
                                                                                                                  Id = Convert.ToInt32(xe.Attribute("id").Value),
                                                                                                                  Name = xe.Attribute("name").Value,
                                                                                                              }).ToList()
                                                                                    }).ToList()                             
                                                       });
