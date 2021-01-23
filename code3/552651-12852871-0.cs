    class Customer { public string CustomerName { get; set; } }
    var customer = new Customer { CustomerName = "bob" };
    Expression<Func<Customer, string, bool>> expression = (c, s) => c.GetType().GetProperty("CustomerName").GetGetMethod().Invoke(c, null).ToString().StartsWith(s, true, null);
    
    var startsResult = expression.Compile()(customer, "b"); // returns true
    startsResult = expression.Compile()(customer, "x"); // returns false
