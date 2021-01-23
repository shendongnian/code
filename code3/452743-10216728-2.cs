    public class CustomerWithOrderCount
    {
        public CustomerWithOrderCount(Customer c, int OrderCount) 
        { 
            Customer = c; 
            this.OrderCount = OrderCount;
        }
        public Customer { get; set; }
        public int OrderCount { get; set; }
    }
    
    public static List<object> GetCustomerOrdersCount()
    {
            using (OrdersDbEntities context = new OrdersDbEntities())
            {
                return context.Customers.Select(
                    c => new CustomerWithOrderCount(c, c.Orders.Count())
                                 .ToList();
            }
    }
