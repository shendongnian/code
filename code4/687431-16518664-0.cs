            var doc = XDocument.Load(@"..\XMLFile1.xml");
            var res = doc.XPathSelectElements("/SNS/uniqueSystem");
            foreach (var item in res)
            {
                var us = new UniqueSystem
                {
                    System = int.Parse(item.Element("system").Value),
                    Label = item.Element("label").Value
                };
                if (item.Element("uniqueSubsystem") != null)
                {
                     // process the logic here
                }
            }
