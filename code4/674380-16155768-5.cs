    CardsDatabase cards = new CardsDatabase();
    string path = @"tokens.xml";
    XmlDocument doc = new XmlDocument();
    doc.Load(path);
    XmlSerializer serializer = new XmlSerializer(typeof(CardsDatabase));
    using (StringReader reader = new StringReader(doc.InnerXml))
    {
        cards = (CardsDatabase)(serializer.Deserialize(reader));
    }
