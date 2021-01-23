    class OrderHandler
    {
        public readonly IEnumerable<Order> Orders;
    
        public OrderHandler()
        {
            Orders = new List<Order>();
        }
    }
    ((List<Order>)OrderHandler.Orders).Add(new Order());
