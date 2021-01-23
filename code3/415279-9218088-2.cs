    var xdoc = XDocument.Load(new StringReader(xml));
    var back = xdoc.Element("root").Elements("i").Select(
        e => new Data {
            Date = DateTime.Parse(e.Attribute("t").Value)
        ,   Code = int.Parse(e.Attribute("a").Value)
        ,   First = e.Element("u").Value
        ,   Last = e.Element("s1").Value
        }
    ).ToList();
