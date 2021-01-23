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
		//It can has only one address
        public Address Address { get; set; } 
    }
