        static void Main(string[] args)
        {
            var settings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse,
                XmlResolver = new XmlResourceResolver()
            };
            using (var reader = XmlReader.Create("root.xml", settings))
            {
                var element = XElement.Load(reader);
                var nameValuePairs = from content in element.Elements()
                                     from value in content.Elements()
                                     select new
                                     {
                                         Name = value.Attribute("Name"),
                                         Value = int.Parse(value.Attribute("Value").Value)
                                     };
                foreach (var pair in nameValuePairs)
                {
                    Console.WriteLine(pair.Name + " " + pair.Value);
                }
            }
        }
