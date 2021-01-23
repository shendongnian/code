    var list = loadedData.Descendants("item")
                         .Select(e => new Site() 
                                      {
                                       Title = e.Element("title")
                                                .Value, 
                                       Url = e.Descendants(media + "content")
                                              .Last()
                                              .Attribute("url")
                                              .Value
                                      })
                         .ToList();
