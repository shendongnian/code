public class Address
    {
        public int addressID { get; set; }
        public string address { get; set; }
    }
public class AdvanceClient
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public int AddressId { get; set; }
        public virtual Address Addresses { get; set; } 
    }
