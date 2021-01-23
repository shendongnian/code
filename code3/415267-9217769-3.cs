    var doc = XDocument.Load("test.xml");
    XNamespace ns = "mynamespace";
    var member = doc.Root.Element(ns + "member");
    // This will *sort* of flatten, but create copies...
    var descendants = member.Descendants().ToList();
    // So we need to strip child elements from everywhere...
    // (but only elements, not text nodes)
    foreach (var descendant in descendants)
    {
        // Need to materialize the list of elements within each descendant,
        // to avoid changing the contents of the collection over which we're
        // iterating
        foreach (var child in descendant.Elements().ToList())
        {
            child.Remove();
        }
    }
    member.ReplaceNodes(descendants);
