            XDocument doc = XDocument.Load(@"Data.xml");
            var result2 = doc.Element("Entities")
                .Elements("Request")
                .GroupBy(key => key.Element("ID").Value, el => DateTime.Parse(el.Element("Finance").Element("StartDate").Value))
                .Select(el =>
                    new
                    {
                        id = el.Key,
                        max2 = el.OrderByDescending(date => date).Take(2)
                    });
