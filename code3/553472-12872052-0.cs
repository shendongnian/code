      var placemarks = xdoc.Descendants(ns + "Placemark")
                                .Select(p => new
                                {
                                    Name = p.Element(ns + "name").Value,
                                    Desc = p.Element(ns + "description").Value,
                                    Coord = p.Descendants(ns + "coordinates")
                                             .First().Value
                                })
                                .ToList();
