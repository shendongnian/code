    [XmlRoot("customers")]
    public class CustomerList {
        [XmlElement("customer")]
        public Customer[] Customers { get; set; }
    }
    public class Customer {
        private String _id;
        
        [XmlElement("name")]
        public String Name {get; set;}
        [XmlElement("id")]
        public String Id {get{return _id;} set{_id = value;}}
        [XmlElement("code")]
        public String Code {get{return _id;} set{_id = value;}}
    }
