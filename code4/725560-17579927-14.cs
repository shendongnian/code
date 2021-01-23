    protected static readonly Dictionary<string, Expression<Func<Order, object>>> sortKeys = new Dictionary<string,Expression<Func<Order,object>>>()
    {
      { "OrderID", x => x.OrderID },
      { "OrderDate", x => x.OrderDate },
      { "TotalPurchaseAmount", x => x.TotalPurchaseAmount },
      { "Comments", x => x.Comments },
      { "Shipped", x => x.Shipped }
    };
