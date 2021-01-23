    [XmlRoot("positions")]
    public class Positions    
    {
        [XmlElement("POS")]
        public ObservableCollection<POS> Collection {get;set;}
    }
