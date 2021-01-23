    XDocument xDoc = XDocument.Parse(xml);
    XNamespace ns = XNamespace.Get("DAV:");
    var responses = xDoc.Descendants(ns + "status")
                        .Where(s => !s.Value.Contains(" 404 "))
                        .Select(s => s.Parent.Parent);
