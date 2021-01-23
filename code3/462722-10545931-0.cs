        public List<Order> GetAllOrders()
        {
            List<Order> orders = null;
            using (NorthwindEntities context = new NorthwindEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;
                orders = context.Set<Order>().Include("Order_Details").AsEnumerable().ToList();
                context.Configuration.ProxyCreationEnabled = true;
            }
            return orders;
        }
