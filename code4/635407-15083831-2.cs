    var doc = new XDocument(new XElement("outputs"));
    var root = doc.Root;
    foreach(var o in outputs)
    {
        root.Add(new XElement("output",
                     new XAttribute("name", o.Name),
                     new XAttribute("value", o.Value),
                     new XAttribute("type", o.Type)));
    }
