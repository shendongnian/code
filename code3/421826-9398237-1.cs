    [XmlRoot("Root")]
    public class SerializeWrapper<TObject>
    {
        [XmlAttribute()]
        public string Name { get; set; }
        public TObject XmlObject { get; set; }
    }
