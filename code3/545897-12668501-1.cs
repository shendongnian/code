    var xDoc = XDocument.Load("logins.xml"); //
    string lastDate = xDoc.Descendants("User")
                          .Where(x => x.Element("Name").Value == "David")
                          .Select(x => DateTime.Parse(x.Element("Date").Value))
                          .OrderByDescending(x => x)
                          .First()
                          .ToString();
