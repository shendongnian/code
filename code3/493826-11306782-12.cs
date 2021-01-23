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
            // You can process each country element individually like this
            foreach (XElement el in elements)
            {
                string name = el.Element("name").Value;
                string _24h = el.Element("_24h").Value;
                string _14h = el.Element("_14h").Value;
            }
