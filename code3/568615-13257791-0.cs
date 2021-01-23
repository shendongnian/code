    var xDoc = XDocument.Load(filename);
    var reminders = xDoc.Descendants("Reminders")
                        .Select(r => new
                        {
                            Name = (string)r.Element("Name"),
                            Title = (string)r.Element("Title"),
                            Content = (string)r.Element("Content"),
                            BeginTime = (DateTime)r.Element("BeginTime"),
                        })
                        .ToList();
 
    var firstTitle = reminders[0].Title;
