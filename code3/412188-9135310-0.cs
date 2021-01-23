    public class Product
    {
        public int productID { get; }
        public string name { get; set; }
    }
    public class OrderItem
    {
        public Product product { get; set; }
        public int quantity { get; set; }
    }
    public class Order
    {
        public int orderID { get; }
        public Customer customer { get; set; }
        public List<OrderItem> items { get; set; }
    }
