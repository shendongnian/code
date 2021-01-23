     public static XElement IgnoreNamespace(this XElement xelem)
        {
            XNamespace xmlns = "";
            var name = xmlns + xelem.Name.LocalName;
            return new XElement(name,
                            from e in xelem.Elements()
                            select e.IgnoreNamespace(),
                            xelem.Attributes()
                            );
        }
    static void Main(string[] args)
    {
        var document = XDocument.Parse("<?xml version=\"1.0\" ?><div xmlns=\"http://www.ya.com\"><div class=\"child\"></div></div>");
        var first = document.Root.Elements().First().IgnoreNamespace();
        Console.WriteLine(first.ToString());
    }
