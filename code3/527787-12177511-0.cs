    XNamespace s = "http://schemas.xmlsoap.org/soap/envelope/";
    XNamespace tempUri = "http://tempuri.org/";
    var xDoc = new XDocument(
                        new XElement(
                            s + "Envelope",
                            new XAttribute(XNamespace.Xmlns + "s", s),
                            new XElement(
                                s + "Body",
                                new XElement(
                                    tempUri+ "GetData",
                                    new XElement(tempUri + "value","Enter my value")
                                )
                            )
                        )
                    );
    var request = xDoc.ToString();
