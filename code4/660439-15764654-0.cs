    public class Customer 
    { 
        public int Id { get; set; }
        
        public virtual ICollection<Company> Companies { get; set; }
    }
    public class Company
    {
        public int Id { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
