    [XmlType]
    public class Data : List<Day>
    {   
    }
    
    [XmlType("D")]
    public class Day
    {
        [XmlAttribute("d")]
        public string Date { get; set; }
    
        [XmlElement("P")]
        public List<Price> Prices { get; set; }
    }
    
    public class Price
    {
        [XmlAttribute("t")]
        public string Time { get; set; }
    
        [XmlText]
        public decimal Value { get; set; }
    }
    public Data ParseXml(TextReader reader)
    {
        var ser = new XmlSerializer(typeof(Data));
        return (Data) ser.Deserialize(reader)
    }
