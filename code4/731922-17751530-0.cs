    [WebMethod]
    public XElement Sum2()
    {
    XNamespace defaultNamespace = XNamespace.Get("http://appserver.weevio.se/schema/SDKr1/Fields.xsd");
    XElement test = new XElement(new XElement(defaultNamespace + "FieldsRoot"));
    string value = "1694.152344;1694.092285;1693.972168;1693.852051";
    string datum = "2013-07-10 20:00:00;2013-07-10 19:00:00;2013-07-10 18:00:00;2013-07-10 17:00:00";
    string[] valueA = value.Split(';');
    string[] datumA = datum.Split(';');
    int d = 0;
    
    Xelement numericElement = new Xelement(); 
    foreach (var customer in valueA)
    {
        XElement xElement = new XElement(defaultNamespace + "Numeric",
                new XAttribute("value", valueA[d]),
                new XAttribute("datum", datumA[d]),
                new XAttribute("status", 16)
        );
        numericElement.Add(xElement);
        d = d + 1;
    }
    test.Add(new XElement(defaultNamespace + "Fields", new XAttribute("ok", "true"), new XAttribute("nodeId", "TEST.HW"), numericElement));
    return test;
}
