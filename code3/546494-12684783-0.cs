    var userElement = xDox.Descendants("User")
                    .SingleOrDefault(u => u.Element("Name").Value == "David");
    
    if (userElement != null)
    {
        var result = userElement.Descendants("Attempts")
            .Select(a => new
                {
                    Place = a.Element("Place").Value,
                    Date = DateTime.Parse(a.Element("Date").Value),
                    Distance = int.Parse(a.Element("Distance").Value)
                })
    
            .Where(a => a.Date >= DateTime.Parse("3/29/2012")
                        && a.Date <= DateTime.Parse("8/29/2012"))
    
            .GroupBy(a => a.Place)
            .Select(g => new {Place = g.Key, Avg = g.Average(x => x.Distance)});
    }
