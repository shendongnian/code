    XDocument xDoc = XDocument.Parse(xml);
    var assets = xDoc.Descendants("Asset")
                        .Select(a=>a.Descendants("Attribute")
                                    .ToDictionary(x => x.Attribute("name").Value, 
                                                  x => x.Value))
                        .ToList();
