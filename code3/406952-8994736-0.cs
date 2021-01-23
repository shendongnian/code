    [Serializable]
    [XmlRoot(Namespace = "http://www.ZomboCorp.com/")]
    public class Prices 
    {
        [XmlElement("pricepoint")]
        public List<Pricepoint> prices { get; set; }
    }
    
    [Serializable]
    public class Pricepoint
    {
    
        [XmlElement("esid")]
        public string Esid { get; set; }
    
        [XmlElement("observationdate")]
        public DateTime Observationdate { get; set; }
    
        [XmlElement("observationtime")]
        public int Observationtime { get; set; }
    
        [XmlElement("price")]
        public double Price { get; set; }
    
        [XmlElement("quote")]
        public string Quote { get; set; }
    
    }
