    var xDoc = XDocument.Load("logins.xml");
    
    var userElements = xDoc.Descendants("User")
        .Where(x => x.Element("Name").Value == "David")
        .ToList();
    
    if (userElements.Any())
    {
        string lastDate = userElements.Select(x => 
                                           DateTime.Parse(x.Element("Date").Value))
            .OrderByDescending(x => x)
            .First()
            .ToString();
    }
