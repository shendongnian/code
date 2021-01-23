    var query = doc.Descendants("tn")
                   .Select(tn => new { Name = tn.Attribute("name").Value,
                                       Min = (int) tn.Element("min"),
                                       Max = (int) tn.Element("max") });
    foreach (var result in query)
    {
        Console.WriteLine("{0}: {1}, {2}", result.Name, result.Min, result.Max);
    }
