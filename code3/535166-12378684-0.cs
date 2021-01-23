    public class Customer
    {
        public virtual IList<Order> Orders { get; set; }
    }
    var customer = new Customer();
    customer.Orders = new List<Order>();
