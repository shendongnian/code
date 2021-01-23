    XElement root = XElement.Load(file); // or .Parse(string)
    var lines = root.Descendants("LINE")
        .Select(line =>
            new
            {
                Id = (string)line.Element("ID"),
                Points = line.Elements("POINT")
                    .Select(p => new PointF
                    {
                        X = (float)p.Attribute("X"),
                        Y = (float)p.Attribute("Y")
                    }).ToArray()
            }).ToArray();
