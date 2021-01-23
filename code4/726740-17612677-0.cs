    XNamespace ns = XNamespace.Get("http://namespace");
    
    var xDocument = new XDocument(
                    new XElement(ns + "Root",
                        new XAttribute(XNamespace.Xmlns + "ns0", ns),
                        new XElement("Node1",
                            new XElement("A", "ValueA"),
                            new XElement("B", "ValueB")
                            )));
