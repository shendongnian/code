        public class Event
        {
            [XmlAttribute]
            public string id { get; set; }
    
            [XmlElement]
            public DogNumber DogNumber { get; set; }
        }
    
        public class DogNumber
        {
            [XmlAttribute]
            public string id { get; set; }
    
            [XmlElement]
            public dogName dogName { get; set; }
    
            [XmlElement]
            public string dogBreed { get; set; }
        }
    
        public class dogName
        {
            [XmlAttribute]
            public string id { get; set; }
    
            [XmlTextAttribute]
            public string value { get; set;  }
        }
