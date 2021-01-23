    public class Customer
    {
        public long CustomerID { get; set; }
        public string CustomerName { get; set; }
        public virtual ICollection<CustomerContact> Contacts { get; set; }
    }
    
    public class CustomerContact
    {
        public long CustomerContactID { get; set; }
        public long CustomerID { get; set; }
        public virtual Customer Owner { get; set; }
        public long Phone { get; set; } // I agree this should be a string
    }
