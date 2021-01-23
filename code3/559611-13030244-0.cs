    var xDoc = XDocument.Parse(xml); //or XDocument.Load(filename);
    XNamespace ns = "http://mws.amazonservices.com/schema/Products/2011-10-01";
    var items = xDoc.Descendants(ns + "ItemAttributes")
                    .Select(x => new
                    {
                        Author = x.Element(ns + "Author").Value,
                        Brand = x.Element(ns + "Brand").Value,
                        Dimesions = x.Element(ns+"ItemDimensions").Descendants()
                                     .Select(dim=>new{
                                         Type = dim.Name.LocalName,
                                         Unit = dim.Attribute("Units").Value,
                                         Value = dim.Value
                                     })
                                    .ToList()
                                                    
                    })
                    .ToList();
