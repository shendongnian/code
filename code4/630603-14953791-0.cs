    public class Community
    {
        public string Author { get; set; }
        public int CommunityId { get; set; }
        public string Name { get; set; }
        [XmlArray]
        [XmlArrayItem(typeof(RegisteredAddress))]
        [XmlArrayItem(typeof(TradingAddress))]
        public List<Address> Addresses { get; set; }
    }
    
    public class Address
    {
        private string _postCode;
    
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    
        public string PostCode
        {
            get { return _postCode; }
            set {
                // validate post code e.g. with RegEx
                _postCode = value; 
            }
        }
    }
    
    public class RegisteredAddress : Address { }
    public class TradingAddress : Address { }
