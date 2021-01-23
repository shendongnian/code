    var xDoc = XDocument.Load("logins.xml");
    DateTime? lastDate = xDoc.Descendants("User")
                             .Where(x => x.Element("Name").Value == "David")
                             .Select(x => DateTime.Parse(x.Element("Date").Value))
                             .OrderByDescending(x => x)
                             .FirstOrDefault();
    string lastDateString = lastDate.HasValue() ? lastDate.Value : string.Empty;
