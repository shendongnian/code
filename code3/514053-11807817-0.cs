    XMLTextReader reader = new XmlTextReader("FooBar.xml");
    ResXResourceWriter writer = new ResXResourceWriter("FooBar.resx");
    while(reader.Read())
    {
        if(reader.NodeType == XmlNodeType.Element && reader.Name == "string")
           writer.AddResource(reader.GetAttribute("name"), reader.ReadString());
    }
    writer.Generate();
    writer.Close();
