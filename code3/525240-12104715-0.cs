    XDocument xDoc = XDocument.Parse(xml);
    var demographics =  xDoc
            .Descendants("country")
            .Select(c => new
            {
                Country = c.Attribute("value").Value,
                Id = c.Attribute("id").Value,
                States = c.Descendants("state")
                            .Select(s => new
                            {
                                State = s.Attribute("value").Value,
                                Id = s.Attribute("id").Value,
                                Cities = s.Descendants("city").Select(x => x.Value).ToList()
                            })
                            .ToList()
            })
            .ToList();
