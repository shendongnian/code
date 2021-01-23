            List<string> names = new List<string>();
            List<string> twentyFour = new List<string>();
            List<string> fourteen = new List<string>();
            XDocument doc = XDocument.Load(@"expenses.xml");
            var elements = doc
              .Element("expenses")
              .Descendants("country");
            names.AddRange(elements
                                .Descendants("name")
                                .Select(i => i.Value)
                                .ToList());
            twentyFour.AddRange(elements
                                .Descendants("_24h")
                                .Select(i => i.Value)
                                .ToList());
            fourteen.AddRange(elements
                                .Descendants("_14h")
                                .Select(i => i.Value)
                                .ToList());
