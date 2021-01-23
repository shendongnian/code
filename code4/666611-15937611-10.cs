    var id = 9000;
    var regKey = "RegistrationKey";
    var inType = 1;
    var prodType = 5;
    var tranCode = 1;
    var soapNs = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
    var v1Ns = XNamespace.Get("http://postilion/realtime/merchantframework/xsd/v1/");
    var xml= new XElement(soapNs + "Envelope",
        new XAttribute(XNamespace.Xmlns + "soapenv", soapNs),
        new XElement(soapNs + "Body",
            new XElement(v1Ns + "SendTranRequest",
                new XAttribute(XNamespace.Xmlns + "v1", v1Ns),
                new XElement(v1Ns + "merc",
                    new XElement(v1Ns + "id", id),
                    new XElement(v1Ns + "regKey", regKey),
                    new XElement(v1Ns + "inType", inType),
                    new XElement(v1Ns + "prodType", prodType)
                ),
                new XElement(v1Ns + "tranCode", tranCode)
            )
        )
    );
