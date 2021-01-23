    [Serializable]
    public class Dimension 
    {
        [XmlAttribute("units")]
        public string Units { get; set; }   
    
        [XmlText]
        public decimal Value { get; set; }
    }
