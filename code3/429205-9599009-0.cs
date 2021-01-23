    from element in XDocument.Parse(queryResponse).Descendants("Movie")
                              select new BaseEvent
                              {
                                  OID = (int)element.Attribute("ID"),
                                  Subject = (string)element.Element("Name"),
                                  Duration = (int)element.Element("Duration").Attribute("Duration")
                              }.First();
