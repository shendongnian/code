    class GetData
    {
        public GetData(Assembly assembly)
        {
            var xml = new XDocument(new XElement("root"));
            foreach (var type in assembly.GetTypes())
            {
                var typeElement = new XElement("Class", new XElement("Name", type.Name));
                
                foreach (var field in type.GetFields())
                {
                    typeElement.Add(new XElement("Field",
                        new XElement("Name", field.Name),
                        new XElement("Type", field.FieldType)));
                }
                
                xml.Root.Add(typeElement);
            }
            Console.WriteLine(xml);
            xml.Save("Dump.xml");
        }
    }
