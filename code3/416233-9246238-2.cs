    XElement viewXml = XElement.Load("test.xml");
    List<ViewCount> viewCounts = viewXml.Descendants("ViewCount")
                                        .Select(x => new ViewCount()
                                        {
                                            Id = (string)x.Attribute("id"),
                                            Views = (int)x.Attribute("views")
                                        }).ToList();
