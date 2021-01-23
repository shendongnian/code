    var xDoc = XDocument.Parse(xml);
    var bases = xDoc.Descendants("base")
                    .Select(b => new
                    {
                        Id= b.Attribute("id").Value,
                        Type = b.Attribute("type").Value
                    })
                    .ToList();
