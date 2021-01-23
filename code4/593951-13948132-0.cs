            XDocument doc = XDocument.Load(@"Data.xml");
            var result = doc.Element("Entities")
                .Elements("Request")
                .GroupBy(el => el.Element("ID").Value)
                .Select(el => 
                    new { 
                        id = el.Key, 
                        max2 = el.OrderByDescending(el2 => DateTime.Parse(el2.Element("Finance").Element("StartDate").Value))
                                    .Take(2)
                                    .Select(el3 => DateTime.Parse(el3.Element("Finance").Element("StartDate").Value)) });
