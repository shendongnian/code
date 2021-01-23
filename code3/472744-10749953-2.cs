    XDocument xDoc = XDocument.Load(......);
    var result = xDoc.Descendants("condition")
                    .Select(c => new {
                        Name = c.Element("name").Value,
                        Rehabs = c.Descendants("rehab")
                                  .Select(r=>new {
                                        Name = r.Element("name").Value,
                                        Url = r.Element("url").Value
                                  })
                                  .ToArray()
                    })
                    .ToArray();
    Console.WriteLine("Condition#: " + result.Length);
    foreach (var cond in result)
    {
        Console.WriteLine("\tCondition[" + cond.Name + "]: " + cond.Rehabs.Length);
        foreach (var rehab in cond.Rehabs)
        {
            Console.WriteLine("\t\t"+ rehab.Name + " , " + rehab.Url);
        }
    }
