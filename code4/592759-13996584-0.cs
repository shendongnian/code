    var xml = XDocument.Parse(Resource1.XMLFile1).Root;
    var parsed = new {
                         Id = xml.Element("id").Value,
                         Widgets = xml.Elements("widget")
                                      .Select(w => new
                                      {
                                          Caption = w.Attribute("caption").Value,
                                          Services = w.Elements("service").Select(s => new
                                          {
                                              Caption = s.Attribute("caption").Value,
                                              XColor = s.Element("xcolor").Value,
                                              XValue = s.Element("xvalue").Value,
                                              XAlert = s.Element("xalert") != null ? s.Element("xalert").Value : null
                                          }).ToList()
                                      }).ToList()
                     };
