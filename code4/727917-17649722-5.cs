    class OrderHandler
    {
        private readonly IEnumerable<Order> _orders;
    
        public OrderHandler()
        {
            // Set orders.
        }
        void SomeMethod()
        {
            _orders = new Order[0];
        }
    }
