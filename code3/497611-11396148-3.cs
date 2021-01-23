            XDocument xdoc = XDocument.Parse(xml);
            foreach (XElement _class in xdoc.Descendants("Class"))
            {
                string name = _class.Attribute("ID").Value;
                Console.WriteLine(name);
                foreach (XElement element in _class.Descendants("Property"))
                {
                    XAttribute attributeValue = element.Attribute("Name");
                    if (attributeValue != null)
                    {
                        string nameAttributeValue = attributeValue.Value;
                        Console.WriteLine(nameAttributeValue);
                    }
                }
            }
