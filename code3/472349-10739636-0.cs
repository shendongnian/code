    XNamespace ns = "http://tempuri.org/";
    IEnumerable<XElement> elements = docWithDecode.Root
                                                  .Elements(ns + "Global")
                                                  .Elements(ns + "Items")
                                                  .Elements(ns + "Item")
                                                  .Elements(ns + "Item");
