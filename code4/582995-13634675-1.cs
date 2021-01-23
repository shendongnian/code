    var xDoc = XDocument.Parse(xmlstring); // XDocument.Load(filename)
    var items = xDoc.Descendants("level1")
                    .First()
                    .Elements("item")
                    .Select(item => new { 
                                        ID = item.Attribute("id").Value, 
                                        Name = item.Attribute("name").Value 
                                    })
                    .ToList();
