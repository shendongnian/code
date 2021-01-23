    public IQueryable<Order> Orders {
      get {
        return OrderSet.Include("OrderDetails");
      }
    }
