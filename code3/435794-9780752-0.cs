    XElement root = XElement.Parse(xml); // XDocument.Load(xmlFile).Root 
    var specsDivs = root.Descendants()
                        .Where(e => e.Name == "div"
                               && x.Attributes.Any(a => a.Name == "id")
                               && x.Attributes.First(a => a.Name == "id).Value == "Specs"
                               && x.Attributes.Any(a => a.Name == "class"));
    foreach(var div in specsDivs)
    {
      div.Attributes.First(a => a.Name == "class").value = string.Empty;
    }
    string newXml = root.ToString()    
