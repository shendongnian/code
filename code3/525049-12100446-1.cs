    public Order Select(long orderID)
    {
        using (var ctx = new BillingSystemEntities())
        {
            return ctx.Orders.Include("OrderItems")
                .FirstOrDefault(n => n.OrderID == orderID);
        }
    }
