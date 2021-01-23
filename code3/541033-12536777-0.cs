    public new IQueryable<Customer> Customers {
        get {
          throw new InvalidOperationException("Use property ActiveCustomers instead.");
        }
    }
