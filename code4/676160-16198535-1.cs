    var container = new Container
    {
        Elements = new ElementBase[] {
            new ElementType1 { Name = "first object", ID1 = 999 },
            new ElementType2 { Name = "second object", ID2 = 31337 }
        }
    };
    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Container));
    serializer.Serialize(stream, container);
