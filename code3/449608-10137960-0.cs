    public class AddressListViewModel 
    {
        public List<AddressViewModel> AddressList { get; set; }
        public bool CanAdd { get; set; }
    }
    public class AddressViewModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
