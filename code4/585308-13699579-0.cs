    List<string> names = new List<string>{ "CaseName", "Beta", "Delta" };
    XDocument xDoc = XDocument.Parse(xml);
    var products = xDoc.Descendants("Product")
                    .Select(p => p.Elements()
                                  .Where(e => names.Contains(e.Name.LocalName))
                                  .OrderBy(e => names.IndexOf(e.Name.LocalName)).ToList())
                    .ToList();
