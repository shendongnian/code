    XDocument xDoc = XDocument.Parse(xml);
    var dict = xDoc.Descendants("student")
                    .ToDictionary(x => x.Attribute("name").Value, 
                                  x => new Info{ 
                                      Addr=x.Attribute("address").Value,
                                      Avg = x.Attribute("avg").Value });
    var cDict = new ConcurrentDictionary<string, Info>(dict);
