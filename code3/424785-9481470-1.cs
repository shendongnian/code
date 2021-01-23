    [Serializable, XmlRoot("delayedquotes"), XmlType("delayedquotes")]
    public class delayedquotes
    {
        public delayedquotes()
        {
            instrument = new List<Instrument>();
        }
        [XmlElement("instrument")]
        public List<Instrument> instrument { get; set; }
    }
    [XmlType("instrument")]
    public class Instrument
    {
        [XmlElement("title")]
        public string title { get; set; }
        [XmlElement("bid")]
        public double bid { get; set; }
        [XmlElement("spot")]
        public double spot { get; set; }
        [XmlElement("close")]
        public double close { get; set; }
        [XmlElement("b_time")]
        public DateTime b_time { get; set; }
        [XmlElement("o_time")]
        public DateTime o_time { get; set; }
        [XmlElement("time")]
        public DateTime time { get; set; }
        [XmlElement("hi")]
        public string hi { get; set; }
        [XmlElement("lo")]
        public string lo { get; set; }
        [XmlElement("offer")]
        public double offer { get; set; }
        [XmlElement("trade")]
        public double trade { get; set; }
    }
