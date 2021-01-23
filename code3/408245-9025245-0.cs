    using (var context = new MyContext())
    {
        var cust = context.Customer.First();
        var custType = cust.CustomerType;
        var pi = typeof (Customer).GetProperty("CustomerType");
        var child = pi.PropertyType.GetProperty("CustomerTypeID");
        var res = child.GetValue(custType, null);
        // this returns value of Customer.CustomerTypeID
    }
