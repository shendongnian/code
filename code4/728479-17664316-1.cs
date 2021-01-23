    var redactedElements = new HashSet<XName>
    {
        "SSN",
        "CreditCard"
    };
    var redactedAttributes = new HashSet<XName>
    {
        "dateofbirth",
        ...
    };
    var elements = doc.Descendants()
                      .Where(x => redactedElements.Contains(x.Name))
                      .ToList();
    foreach (var element in elements)
    {
        element.Value = "RemovedForSecurity";
    }
    var attributes = doc.Descendants()
                        .Attributes()
                        .Where(x => redactedAttributes.Contains(x.Name))
                        .ToList();
    foreach (var attribute in attributes)
    {
        attribute.Value = "RemovedForSecurity";
    }
