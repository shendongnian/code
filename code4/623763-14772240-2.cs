    static void Main(string[] args)
    {
        object[] components = new object[] { new Component_1(), new Component_1() };
        var doc = new XmlDocument();
        doc.Load("source.xml");
        var project = doc.GetElementsByTagName("project")[0];
        var nav = project.CreateNavigator();
        var emptyNamepsaces = new XmlSerializerNamespaces(new[] { 
            XmlQualifiedName.Empty
        });
        foreach (var component in components)
        {
            using (var writer = nav.AppendChild())
            {
                var serializer = new XmlSerializer(component.GetType());
                writer.WriteWhitespace("");
                serializer.Serialize(writer, component
                    , emptyNamepsaces
                    );
                writer.Close();
            }
        }
        foreach (XmlNode node in doc.GetElementsByTagName("anyType"))
        {
            string attributeType = "";
            foreach (XmlAttribute xmlAttribute in node.Attributes)
            {
                if (xmlAttribute.LocalName == "type")
                { 
                attributeType=xmlAttribute.Value.Split(':')[1];
                }
            }
            node.Attributes.RemoveAll();
            node.CreateNavigator().CreateAttribute("","type","",attributeType);
        }
        doc.Save("output.xml");
    }
