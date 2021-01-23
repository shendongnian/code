    var element = XDocument.Parse(queryResponse)
                           .Descendants("Movie")
                           .FirstOrDefault();
    if (element == null)
    {
        // Handle the case of no movies
    }
    else
    {
        var baseEvent = new BaseEvent
                        {
                            OID = (int) element.Attribute("ID"),
                            Subject = (string) element.Element("Name"),
                            Duration = (int) element.Element("Duration")
                                                    .Attribute("Duration")
                        };
        // Use baseEvent
    }
