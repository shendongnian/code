    public partial class Address
    {
        public int AddressId { get; set; }    
    
        public int? AccountHolderId { get; set; }
        public AccountHolder AccountHolder { get; set; }
    
        public int? NomineeId { get; set; }
        public Nominee Nominee { get; set; }
    }
