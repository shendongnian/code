    public Order Select(long orderID)
    {
        using (var ctx = new BillingSystemEntities())
        {
            var res = from n in ctx.Orders.Include("OrderItems")
                      where n.OrderID == orderID
                      select n;
            return res.FirstOrDefault();
        }
    }
