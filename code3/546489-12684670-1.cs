    XElement x = XElement.Load("In.xml");
    IFormatProvider f = new System.Globalization.CultureInfo("en-US");
    var info = x.Elements("User").Select(u => new
    {
        Name = u.Element("Name").Value,
        AverageAttempts = u.Elements("Attempts")
                           .GroupBy(a => a.Element("Place").Value)
                           .Select(g => new
                           {
                              Place = g.Key,
                              BeginDate = g.Elements("Date")
                                           .Select(d => DateTime.Parse(d.Value, f))
                                           .Min(),
                              EndDate = g.Elements("Date")
                                         .Select(d => DateTime.Parse(d.Value, f))
                                         .Max(),
                              Distance = g.Elements("Distance")
                                          .Average(d => decimal.Parse(d.Value))
                           })
    });
    foreach (var i in info)
    {
        Console.WriteLine(i.Name);
        foreach (var aa in i.AverageAttempts)
        {
            Console.WriteLine(
             string.Format(
              "{0} [{1} - {2}]:\t{3}",aa.Place,aa.BeginDate,aa.EndDate,aa.Distance));
        }
        Console.WriteLine();
    }
