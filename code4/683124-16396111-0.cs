    var classToRemove = "highlights-tracker";
    var xml = XDocument.Parse(svg);
    var elements = doc.Descendants("path")
                      .Where(x => x.Attribute("class") != null &&
                                  x.Attribute("class")
                                   .Value.Split(' ')
                                   .Contains(classToRemove));
    // Remove all the elements which match the query
    elements.Remove();
                                  
