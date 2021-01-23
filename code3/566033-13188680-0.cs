    foreach (Name name in names)
    {
        var dates = doc.Element("Team").Element("Dates");
        if (dates.Parent.Element("Name").Value == name.TeamName)
        {
            dates.Add(
                new XElement("Game",
                    new XElement("Bench", "SomeBench"),
                    new XElement("Date", SomeDate.ToShortDateString())
                )
            );
        }
    }
