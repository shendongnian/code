    using System.Xml.Linq;
            var f = XDocument.Load("c:\\01.xml");
            var xsi = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");
            var nills = from n in f.Root.Elements("prop1").Elements()
                        where n.Attribute(xsi + "nil") != null
                        select n;
            nills.ToList().ForEach(x => x.RemoveAttributes());
            f.Save("c:\\011.xml");
