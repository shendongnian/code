    XDocument xml = new XDocument(
                                  new XElement("product",
                                                         new XElement("name", pName),
                                                         new XElement("price", pPrice)
                                              )
                                 );
    string xmlString = xml.ToString();
