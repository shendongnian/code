    var s = "<ProcessRequestResponse.....";
    var doc = XDocument.Parse(s);
    string value = doc.Element("ProcessRequestResponse")
    .Element("ProcessRequestResult")
    .Element("ConsumerAddEntryResponse")
    .Element("Status")
    .Value;
