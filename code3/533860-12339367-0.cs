    XDocument xDoc = XDocument.Load(....);
    XNamespace ns = "http://www.opengis.net/kml/2.2";
    var placemarks = xDoc
                .Descendants(ns + "Placemark")
                .Select(p => new
                {
                    Name = p.Element(ns+"name").Value,
                    Longitude = p.Element(ns+"LookAt").Element(ns+"longitude").Value,
                    Latitude = p.Element(ns+"LookAt").Element(ns+"latitude").Value,
                })
                .ToArray();
