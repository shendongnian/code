    public class Customer
    {
        public IEnumerable<Order> Orders { get; set; }
    }
    public class Order
    {
        public IEnumerable<OrderLine> OrderLines { get; set; }
    }
    public class OrderLine
    {
        /*
         * ...
         */
    }
