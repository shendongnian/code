    Person person; // Assuming it is populated as above
    using(MemoryStream memoryStream = new MemoryStream())
    {
        xmlSerializer.Serialize(memoryStream, person, 
            new XmlSerializerNamespaces(new [] { new XmlQualifiedName("q1", "http://api.google.com/staticInfo/") }));
        memoryStream.Flush();
        Console.Out.WriteLine(Encoding.UTF8.GetChars(memoryStream.GetBuffer()));
    }
