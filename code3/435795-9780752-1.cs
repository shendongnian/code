    XElement root = XElement.Parse(xml); // XDocument.Load(xmlFile).Root 
    var specsDivs = root.Descendants()
                        .Where(e => e.Name == "div"
                               && e.Attributes.Any(a => a.Name == "id")
                               && e.Attributes.First(a => a.Name == "id").Value == "Specs"
                               && e.Attributes.Any(a => a.Name == "class"));
    foreach(var div in specsDivs)
    {
      div.Attributes.First(a => a.Name == "class").value = string.Empty;
    }
    string newXml = root.ToString()    
