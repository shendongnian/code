    public static List<object> GetCustomerOrdersCount()
    {
            using (OrdersDbEntities context = new OrdersDbEntities())
            {
                return context.Customers.Select().ToList<Customer>();
            }
    }
