    var doc = XDocument.Load("test.xml");
    XNamespace ns = "mynamespace";
    var member = doc.Root.Element(ns + "member");
    // This will *sort* of flatten, but create copies...
    var descendants = member.Descendants().ToList();
    // So we need to strip child elements from everywhere...
    // (but only elements, not text nodes)
    foreach (var descendant in descendants)
    {
        foreach (var child in descendants.Elements())
        {
            child.Remove();
        }
    }
    member.ReplaceNodes(descendants);
