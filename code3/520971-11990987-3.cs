    XNamespace ns = "http://www.someurl.org/schemas";
    var entries = elm.Descendants().Where(x => x.Name.LocalName == "Entry").ToList();
    foreach (XElement v in entries)
    {
        Console.WriteLine(v.Element(ns+"Date").Value);
        Console.WriteLine(v.Element(ns+"Time").Value);
    }
