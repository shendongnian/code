    var doc = XDocument.Load("test.xml");
    XNamespace ns = "mynamespace";
    var member = doc.Root.Element(ns + "member");
    // This will *sort* of flatten, but create copies...
    var descendants = member.Descendants().ToList();
    // So we need to strip child elements from everywhere...
    // (but only elements, not text nodes). The ToList() call
    // materializes the query, so we're not removing while we're iterating.
    foreach (var nested in descendants.Elements().ToList())
    {
        nested.Remove();
    }
    member.ReplaceNodes(descendants);
