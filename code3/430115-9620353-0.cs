    XDocument doc = ...; // However you want to load this.
    // Note: XML is case-sensitive, which is one reason your code failed before
    List<string> books = doc
        .Descendants("Intel")
        // Not really necessary, but makes it simpler
        .Select(x => new {
                   Title = (string) x.Element("Title"),
                   Author = x.Element("Intel_auth")
                })
        .Select(x => new {
                   Title = x.Title,
                   FirstName = (string) x.Author.Element("fname"),
                   MiddleInitial = (string) x.Author.Element("mname"),
                   LastName = (string) x.Author.Element("lname"),
                });
        .Select(x => string.Format("{0}: {1} {2} {3}",
                                   x.Title,
                                   x.FirstName, x.MiddleInitial, x.LastName))
        .ToList();
