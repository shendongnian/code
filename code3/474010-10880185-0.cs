        public decimal GetOrders(decimal order)
        {
            totalOrders += order;
            return order;
        }
        public decimal GetOrdersTotal()
        {
            return totalOrders;
        }
