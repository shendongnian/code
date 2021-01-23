            string xml = @"<ConfiguratorConfig xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
    <Section>
        <Class ID=""Example"" Name=""CompanyName.Example"" Assembly=""Example.dll"">
            <Interface>
                <Property Name=""exampleProperty1"" Value=""exampleValue"" />
                <Property Name=""exampleProperty2"" Value=""exampleValue"" />
                <Property Name=""exampleProperty3"" Value=""exampleValue"" />
            </Interface>
        </Class>
    </Section></ConfiguratorConfig>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var classNode = doc.SelectSingleNode(@"/ConfiguratorConfig/Section/Class");
            if (classNode != null)
            {
                string name = classNode.Attributes["ID"].Value;
                Console.WriteLine(name);
                foreach (XmlElement element in classNode.SelectNodes(@"Interface/Property"))
                {
                    if(element.HasAttribute("Name"))
                    {
                        string nameAttributeValue = element.Attributes["Name"].Value;
                        Console.WriteLine(nameAttributeValue);
                    }
                }
            }
            Console.ReadKey();
