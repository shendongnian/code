System.Xml.Linq
    XElement xElem = new XElement("r");
    for (int i = 0; i < 3; i++)
    {
        xElem.Add(
            new XElement("i",
                    new XAttribute("t", "234233"),
                    new XAttribute("a", "3"),
                    new XElement("u", "UserName"),
                    new XElement("s1", "This is a string")
            )
        );
    }
    var str = xElem.ToString();
