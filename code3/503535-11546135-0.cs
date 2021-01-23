    var list = loadedData.Descendants("item")
                         .Select(e => new Site() 
                                      {
                                       Title = e.Element("title")
                                                .Value, 
                                       Url = e.Descendants("content")
                                              .Last()
                                              .Attribute(media + "url")
                                              .Value
                                      })
                         .ToList();
