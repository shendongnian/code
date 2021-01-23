    XElement elementPrecedingOptionalElement = new XElement(...);
    var xml = new XDocument(....,
       new XElement(...),
       new XElement(...),
       elementPrecedingOptionalElement,
       new XElement(...),
       new XElement(...)
    );
    if (x == 42)
       elementPrecedingOptionalElement.AddAfterSelf(new XElement(...));
