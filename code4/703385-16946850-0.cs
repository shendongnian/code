    var xDoc = XDocument.Load(filename);
    
    var result = xDoc.Descendants("HOTSPOT")
                    .Select(h => new
                    {
                        Name = (string)h.Attribute("NAME"),
                        Media = (string)h.Attribute("MEDIA"),
                        X = (int)h.Attribute("X"),
                        // .......
                    })
                    .ToList();
