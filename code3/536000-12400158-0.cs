            XElement x = XElement.Load("In.xml");
            string prefix = "w";
            XNamespace w = x.GetNamespaceOfPrefix(prefix);
            var ds = x.Descendants(w + "p")
                      .Where(d => string.IsNullOrEmpty(d.Value));
            ds.Remove();
            x.Save("Out.xml");
