    XDocument xDoc = XDocument.Parse(xml);
    var result = xDoc.Descendants("ticket")
                     .Select(n => new
                        {
                            Subject = n.Element("subject").Value,
                            Status = (string)n.Descendants("value").LastOrDefault()
                        })
                    .ToList();
