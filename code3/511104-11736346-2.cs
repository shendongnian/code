    public class Time{
        [XmlAttrubute]
        public string value {get; set; }
        [XmlText]
        public string Text {get;set;} // this will hold the innerText value ("10") of <Time>
    }
    public class Prod{
        [XmlAttrubute]
        public string Name {get; set; }
        [XmlElement("Time")]
        public List<Time> Time {get; set; }
    }
    
    [XmlRoot("parent")]
    public class Parent{
        [XmlElement(ElementName="ProdToNet", Type=typeof(Prod))]
        [XmlElement(ElementName="TotProd", Type=typeof(Prod))]
        public List<Prod> {get; set;}
    }
