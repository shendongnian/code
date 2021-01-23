            XDocument doc = XDocument.Load(<path to file>);
            XNamespace ns1 = "http://www.w3.org/2000/svg";
            //Namespace of a root element can also be retrieved like this:
            //XNamespace ns1 = doc.Root.GetDefaultNamespace();
            var g = doc.Descendants(ns1 + "g").FirstOrDefault();
            if (g != null)
            {
                var flowroot = g.Element(ns1 + "flowRoot");
                var text = g.Element(ns1 + "text");
            }
