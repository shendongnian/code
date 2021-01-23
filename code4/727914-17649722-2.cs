    class OrderHandler
    {
        public readonly IEnumerable<Order> Orders;
    
        public OrderHandler()
        {
            Orders = new List<Orders>();
        }
    }
    ((List<Orders>)OrderHandler.Orders).Add(new Order());
