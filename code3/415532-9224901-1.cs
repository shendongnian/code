    [Serializable()]
    [XmlRoot("Hand")]
    public class Hand : IXmlSerializable {
        [XmlAttribute("cards")]
        public List<string> Cards { get; set; }
        public System.Xml.Schema.XmlSchema GetSchema() { return null; }
        public void ReadXml(XmlReader reader) {
            this.Cards = new List<string>(reader.GetAttribute("cards").Split(','));
        }
        public void WriteXml(XmlWriter writer) {
            writer.WriteAttributeString("cards", 
                 string.Join(",", 
                    this.Cards != null ? this.Cards : new List<string>()));
        }
    }
