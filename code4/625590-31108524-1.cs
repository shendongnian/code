    // Entity class.
    public class Customer
    {
        public string Name { get; set; }
    }
    // Mapper class.
    public class CustomerMapper : EntityMap<Customer>
    {
        public CustomerMapper()
        {
            Map(p => p.Name).ToColumn("Customer Name");
        }
    }
    // Initialise like so - 
    FluentMapper.Initialize(a => a.AddMap(new CustomerMapper()));
