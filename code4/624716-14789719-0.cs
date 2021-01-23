    var xElem = XDocument.Parse(xml).Element("list"); //or XDocument.Load(filename)
    var list = new
                {
                    Name = xElem.Attribute("name").Value,
                    Author = xElem.Attribute("author").Value,
                    Desc = xElem.Attribute("desc").Value,
                    Items = xElem.Elements("item")
                                .Select(e => new{
                                    Color = e.Attribute("color").Value,
                                    Done = (bool)e.Attribute("done"),
                                    Value = e.Value,
                                })
                                .ToList()
                };
