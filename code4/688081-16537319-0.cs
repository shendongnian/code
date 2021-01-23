    var xDoc = XDocument.Load(filename);
    var actions = xDoc.Descendants("Action")
                        .Select(action => new
                        {
                            Name = action.Attribute("Name").Value,
                            Trigger = new
                            {
                                Name = (string)action.Element("Trigger").Attribute("Name"),
                                Conditions = action.Element("Trigger")
                                                .Elements().First()
                                                .Elements()
                                                .Select(e => new{
                                                    Name = e.Parent.Name.LocalName,
                                                    Attributes = e.Attributes().ToDictionary(a=>a.Name.LocalName,a=>a.Value)
                                                })
                                                .ToList()
                            },
                            Command = new
                            {
                                Name = (string)action.Element("Trigger").Attribute("Name"),
                                Do = action.Element("Command")
                                           .Elements().First()
                                           .Elements()
                                           .Select(e => new
                                            {
                                                Name = e.Parent.Name.LocalName,
                                                Attributes = e.Attributes().ToDictionary(a => a.Name.LocalName, a => a.Value)
                                             })
                                            .ToList()
                            },
                        })
                        .ToList();
