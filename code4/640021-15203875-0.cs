    var query = from l in xmlDoc.Descendants("Person")
                select new Notch
                {
                    name = (string)l.Attribute("name").Value,
                    Titles = l.Element("Details").Elements("detail")
                              .Select(s => s.Attribute("games").Value)
                              .ToList(),
                    Image = l.Element("Details").Elements("detail")
                             .Elements("event_image").Elements("image")
                             .Select(x => x.Attribute("url").Value).ToList()
                };
    foreach (var result in query)
    {
        Console.WriteLine(result.name);
        foreach (var detail in result.Titles.Zip(result.Image, (st, si) => string.Format("{0} {1}", st, si)))
        {
            Console.WriteLine(detail);
        }
    }
