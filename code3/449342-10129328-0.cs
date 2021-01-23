    var xs = XNamespace.Get("http://www.w3.org/2001/XMLSchema");
    var doc = XDocument.Load(sourceName + sourceApi + "Input.txt");
    foreach (var el in doc.Descendants(xs + "element"))
    {
        Trace.WriteLine("ANDY ------ " + el.Attribute("name").Value);
        foreach (var attr in el.Elements(xs + "complexType").Elements(xs + "attribute"))
        {
            Trace.WriteLine(attr.Attribute("name").Value);
        }
    }
