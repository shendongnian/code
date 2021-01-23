    XDocument file = XDocument.Parse(xml);
    var persons
      = file.Descendants("rows")
            .Select (x => 
                {
                    var person = new Person();
                    var values = x.Descendants("row")
                                  .GroupBy(y => y.Element("name").Value, 
                                           y => y.Element("value").Value)
                                  .ToDictionary (y => y.Key, y => y.First());
                    foreach(var value in values)
                    {
                        switch (value.Key)
                        {
                            case "Street":
                                person.Street = value.Value;
                                break;
                            case "House number":
                                person.Housenumber = value.Value;
                                break;
                            case "Postal":
                                person.Postal = value.Value;
                                break;
                            case "Area":
                                person.Area = value.Value;
                                break;
                        }
                    }
                    return person;
                });
