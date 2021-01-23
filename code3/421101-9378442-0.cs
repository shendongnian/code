    var settings = new XmlReaderSettings
    {
        ConformanceLevel = ConformanceLevel.Fragment
    };
    using (var reader = XmlReader.Create(stream, settings))
    {
        while (!reader.EOF)
        {
            reader.MoveToContent();
            var doc = XDocument.Load(reader.ReadSubtree());
            reader.ReadEndElement();
            Console.WriteLine("X={0}, Y={1}",
                (int)doc.Root.Element("x"),
                (int)doc.Root.Element("y"));
        }
    }
