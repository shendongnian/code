    [WebMethod] 
    public void SaveAddress(List<Address> Addresses) { 
    // save em here
    }
    
    public class Address
    {
        public Address()
        {
            streetAddress1 = streetAddress2 = apartmentNumber = city = state = zipCode = country = String.Empty;
        }
        public String streetAddress1 { get; set; }
        public String streetAddress2 { get; set; }
        public String apartmentNumber { get; set; }
        public String city { get; set; }
        public String state { get; set; }
        public String zipCode { get; set; }
        public String country { get; set; }
    }
