    public class Customer
    {
        public virtual IList<Order> Orders { get; protected set; }
    }
    var customer = new Customer();
    //customer.Orders = new List<Order>(); // error: can't modify property
    var orderCount = customer.Orders.Count; // this will trigger lazy-loading
