    using System.Xml.Serialization;
    ...
    // Output the XML to this stream
    Stream stream;
    // Create a test object
    UDPCollection udpCollection = new UDPCollection();
    udpCollection.LUPD = 86;
    udpCollection.UDPs = new []
    {
        new UDP() { Id= 106, ERs = new [] { new ER() { LanguageR = "CREn" }}}
    };
    // Serialize the object
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(UDPCollection));
    xmlSerializer.Serialize(stream, udpCollection);
