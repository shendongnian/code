        XDocument doc = XDocument.Load(@"Data.xml");
        TagContents[] ArrayNode = doc.Root
                                    .Elements()
                                    .Select(el =>
                                        new TagContents()
                                        {
                                            TagName = el.Name.ToString(),
                                            TagValue = el.Value
                                        })
                                    .ToArray();
