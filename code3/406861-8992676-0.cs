    XDocument doc = XDocument.Load("file.xml");
    var query = doc.Descendants("raw")
                   .Select(raw => new {
                               A = (string) raw.Element("A"),
                               Interval2 = raw.Element("interval2")
                                              .Elements("type2")
                                              .Select(type2 => (string) type2)
                                              .ToList()
                           });
    foreach (var item in query)
    {
        Console.WriteLine("A: {0}", item.A);
        Console.WriteLine("Interval2 values:");
        foreach (var x in item.Interval2)
        {
            Console.WriteLine("  {0}", x);
        }
    }
