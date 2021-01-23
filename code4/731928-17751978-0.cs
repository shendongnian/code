    Items = configFiles.Select((item, index) => new { Doc = XDocument.Parse(item),
                                                      Index = index })
                       .SelectMany(pair => pair.Doc.Root.Elements("Item")
                                               .Select(x => new { Item = x, 
                                                                  Index = pair.Index }))
                       .OrderBy(pair => pair.Index)
                       .ThenBy(pair => (string) pair.Attribute("ID"));
