    XDocument document = XDocument.Parse(xml);
    XNamespace ns = document.Root.GetDefaultNamespace();
    var responsesExcept404s = document
        .Descendants(ns + "response")
        .Where(x => !x.Descendants(ns + "status")
                      .Single()
                      .Value.Contains("404"));
