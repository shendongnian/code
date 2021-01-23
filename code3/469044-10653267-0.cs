    [Serializable]
    [XmlRoot(ElementName = "Customer")]
    public class SimplifiedCustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [XmlIgnore]
        public long CustomerId { get; set; }
    }
