    string path = @"~/tokens.xml";
    var doc = XDocument.Load(Server.MapPath(Url.Content(path)));
    var cards = doc.Descendants("card")
        .Select(x =>
            new Token
            {
                Name = x.Element("name").Value,
                SetURLs = x.Elements("set").Select(y => y.Attribute("picURL").Value)
                                           .ToList(),
                SetNames = x.Elements("set").Select(y => y.Value).ToList(),
                Color = x.Element("color").Value,
                PT = x.Element("pt").Value,
                Text = x.Element("text").Value
            }).ToList();
