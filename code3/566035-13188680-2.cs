    var teamNames = names.Select(n => n.TeamName);
    foreach (var dates in doc.Elements("Team").Select(t => t.Element("Dates")))
    {
        if (teamNames.Any(s => s == dates.Parent.Element("Name").Value))
        {
            dates.Add(
                    new XElement("Bench", "SomeBench"),
                    new XElement("Date", SomeDate.ToShortDateString())
                );
        }
    }
