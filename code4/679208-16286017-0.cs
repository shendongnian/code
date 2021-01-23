    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public int Quantity { get; set; }
        public virtual List<OrderItem> ordersItems { get; set; }
    }
    public class Order
    {
        public int ID { get; set; }
        public bool Status { get; set; }
        public virtual Account account { get; set; }
        public virtual List<OrderItem> Items { get; set; }        
    }
    public class OrderItem
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public long TotalPrice { get; set; } // It is better to hold the price. What if you later changed the product price?
    }
