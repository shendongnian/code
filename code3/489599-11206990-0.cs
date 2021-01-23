    public class ContactInfo : Entity<int>
    {
        public ContactInfo()
        {
            Addresses = new HashSet<Address>();          
        }
    
        protected virtual ISet<Address> AddressesCollection { get ; private set; }
    
        public IEnumerable<Address> Addresses { get { return AddressesCollection; }}
    
        public Address PrimaryAddress
        {
            get { return Addresses.FirstOrDefault(a => a.IsPrimary); }
        }
    
        public bool AddAddress(Address address)
        {
            // insure there is only one primary address in collection
            if (address.IsPrimary)
            {                  
                if (PrimaryAddress != null)
                {
                    PrimaryAddress.IsPrimary = false;
                }
            }
            else
            {
                // make sure the only address in collection is primary
                if (!Addresses.Any())
                {
                    address.IsPrimary = true;
                }
            }
            return Addresses.Add(address);
        }
    }
