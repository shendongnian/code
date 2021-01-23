    XElement element = XElement.Parse(xml) // XDocument.Load(xmlFile).Root
    int ccNumber;
    IEnumerable<XElement> elementsWithPossibleCCNumbers = 
            element.Descendants()
                   .Where(d => d.Attributes()
                                .Where(a => a.Value.Length == 16)
                                .Where(a => int.TryParse(a.Value, out ccNumber))
                                .FirstOrDefault() != null);
    // Do not use ccNumber 
    // Use elementsWithPossibleCCNumbers
