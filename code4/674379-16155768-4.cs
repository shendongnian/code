    [XmlRoot(ElementName = "card_database")]
    public class CardsDatabase
    {
        public CardsDatabase()
        {
            
        }
        [XmlElement(ElementName = "cards", Form = XmlSchemaForm.Unqualified)]
        public CardsList Cards { get; set; }
        [XmlAttribute(AttributeName = "version", Form = XmlSchemaForm.Unqualified)]
        public string Version { get; set; }
    }
    [XmlRoot(ElementName = "cards")]
    public class CardsList
    {
        public CardsList()
        {
            Cards = new List<Card>();
        }
        [XmlElement(ElementName = "card", Form = XmlSchemaForm.Unqualified)]
        public List<Card> Cards { get; set; } 
    }
    [XmlRoot(ElementName = "card")]
    public class Card
    {
        public Card()
        {
            SetURLs = new List<SetItem>();
        }
        [XmlElement(ElementName = "name", Form = XmlSchemaForm.Unqualified)]
        public string Name { get; set; }
        [XmlElement(ElementName = "set", Form = XmlSchemaForm.Unqualified)]
        public List<SetItem> SetURLs { get; set; }
        [XmlElement(ElementName = "color", Form = XmlSchemaForm.Unqualified)]
        public string Color { get; set; }
        [XmlElement(ElementName = "pt", Form = XmlSchemaForm.Unqualified)]
        public string PT { get; set; }
        [XmlElement(ElementName = "text", Form = XmlSchemaForm.Unqualified)]
        public string Text { get; set; }
    }
    [XmlRoot(ElementName = "set")]
    public class SetItem
    {
        public SetItem()
        {
        }
        [XmlAttribute(AttributeName = "picURL", Form = XmlSchemaForm.Unqualified)]
        public string PicURL { get; set; }
        [XmlAttribute(AttributeName = "picURLHq", Form = XmlSchemaForm.Unqualified)]
        public string PicURLHq { get; set; }
        [XmlAttribute(AttributeName = "picURLSt", Form = XmlSchemaForm.Unqualified)]
        public string PicURLSt { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
