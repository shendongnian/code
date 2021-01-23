    foreach (var dates in doc.Elements("Team")
                             .Where(t => names.Any(n => n.TeamName == t.Element("Name").Value))
                             .Select(t => t.Element("Dates")))
    {
        dates.Add(
                new XElement("Bench", "SomeBench"),
                new XElement("Date", SomeDate.ToShortDateString())
            );
    }
