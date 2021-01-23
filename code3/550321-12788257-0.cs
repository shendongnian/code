    XNamespace ns = "http://earth.google.com/kml/2.2";
    var doc = XDocument.Load("file.xml");
    var query = doc.Root
                   .Element(ns + "Document")
                   .Elements(ns + "Placemark")
                   .Select(x => new PlaceMark // I assume you've already got this
                           {
                               Name = x.Element(ns + "name").Value,
                               Description = x.Element(ns + "description").Value,
                               // etc
                           });
