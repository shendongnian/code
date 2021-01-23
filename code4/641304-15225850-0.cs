            var doc = XDocument.Load(@"D:\input.xml");
            var x = new List<XElement>();
            foreach (var xElement in doc.Root.Elements("Event"))
            {
                DateTime maxDt = DateTime.MinValue;
                foreach (var element in xElement.Elements("SubEvent"))
                {
                    var attributeValue = element.Attributes("update").FirstOrDefault();
                    if (attributeValue == null) continue;
                    DateTime dt;
                    if (!DateTime.TryParse(attributeValue.Value, out dt)) continue;
                    if (maxDt < dt) maxDt = dt;
                }
                xElement.RemoveNodes();
                xElement.Add(new XElement("SubEvent", new XAttribute("update", maxDt.ToString("yyyy-MM-dd HH:mm:ss"))));
                x.Add(new XElement(xElement));
            }
            new XDocument(new XElement("ev", x)).Save(@"D:\output.xml");
