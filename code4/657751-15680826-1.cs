    public class CustomerWrapper
    {
        private Customer _customer;
        public CustomerWrapper (Customer customer)
        {
            _customer = customer;
        }
    
        public bool HasRelation{get;set;}
        public Customer Customer { get {return _customer;}}
    }
