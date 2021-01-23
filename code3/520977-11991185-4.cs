    XNamespace namespc = "http://www.someurl.org/schemas";
    var document = XDocument.Parse(xml);
    var dateAndTimes =
        from d in document.Root.Descendants(namespc + "Entry")
        select new
                    {
                        Date = d.Element(namespc + "Date").Value,
                        Time = d.Element(namespc + "Time").Value
                    };
