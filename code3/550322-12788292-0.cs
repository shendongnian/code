    var xDoc = XDocument.Load("a.xml");
    XNamespace ns = "http://earth.google.com/kml/2.2";
    var placemarks = xDoc.Descendants(ns+"Placemark")
                        .Select(p => new
                        {
                            Name = p.Element(ns+"name").Value,
                            Desc = p.Element(ns+"description").Value
                        })
                        .ToList();
