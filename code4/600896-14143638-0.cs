    var wrapper = new ExampleWrapper();
    var textes = new[] { "Hello, Curtis", "Good-bye, Curtis" };
    foreach(var s in textes)
    {
        wrapper.Add(new Example { ExampleText = s });
    }
    
    XmlAttributeOverrides overrides = new XmlAttributeOverrides();
    XmlAttributes attributes = new XmlAttributes();
    XmlTypeAttribute typeAttr = new XmlTypeAttribute();
    typeAttr.TypeName = "example";
    attributes.XmlType = typeAttr;
    overrides.Add(typeof(Example), attributes);
    
    XmlSerializer serializer = new XmlSerializer(typeof(ExampleWrapper), overrides);
    using(System.IO.StringWriter writer = new System.IO.StringWriter())
    {
        serializer.Serialize(writer, wrapper);
        Console.WriteLine(writer.GetStringBuilder().ToString());
    }
