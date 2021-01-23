    XElement xElem2 = XElement.Load(new StringReader(str));
    foreach(var item in xElem2.Descendants("i"))
    {
        Console.WriteLine(item.Attribute("t").Value + " " + item.Element("u").Value);
    }
