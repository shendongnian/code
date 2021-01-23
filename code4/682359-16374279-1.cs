    public IQueryable<MyCustomerResult> GetMyCustomerByLastName(string startingLastNameLetter)
    {
       //you should modify query to return data that you need, this is only example
       return this.ObjectContext.Customers.Where(c => c.LastName.StartsWith(startingLastNameLetter) == true).Select(c=>new MyCustomerResult  {CustomerID=c.CustomerID,CustomerName=c.CustomerName,OrderDate=c.Orders.Select(o=>o.OrderDate).FirstOrDefault()});
    }
