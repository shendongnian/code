    public partial class Person : BaseEntity 
    {
        [Key]
        public int ID { get; set; }
        public virtual ICollection<AddressBook> AddressBookEntries { get; set; }
        public IEnumerable<Address> Addresses
        {
            get { return AddressBookEntries.Select(ab => ab.Address); }
        }
    }
