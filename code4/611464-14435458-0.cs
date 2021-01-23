    public class Order
    {
        public string Customer { get; set; }
        public decimal Amount { get; set; }
    
        List<OrderDetail> details;
        public List<OrderDetail> Details { get { return details; } }
    
        public Order()
        {
            details = new List<OrderDetail>();
        }
    }
