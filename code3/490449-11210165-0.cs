    public class Customer
    {
        public string Name { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
    
    public class Order
    {
        public int Id { get; set; }
    }
