            XDocument doc = XDocument.Load("Data.xml");
            var categoriesElement = new XElement("categories");
            var categoryElements = doc.Root.Elements("category");
            foreach(var el in categoryElements.ToList())
            {
                categoriesElement.Add(new XElement(el));
                el.Remove();
            }
            doc.Element("results").Add(categoriesElement);
