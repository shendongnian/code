    XDocument xDoc = XDocument.Load(....);
    var result = xDoc.Descendants("condition")
                        .Select(c => c.Descendants("rehab")
                                    .Select(r=>new{
                                                Name=r.Element("name").Value,
                                                Url=r.Element("url").Value
                                            }).ToArray())
                        .ToArray();
