    public IQueryable<MyCustomerResult> GetMyCustomerByLastName(string startingLastNameLetter)
    {
       //you should modify query to return data that you need, this is only example
       var q = from customer in this.ObjectContext.Customers 
               from order in this.ObjectContext.Orders
               where c.CustomerID = o.CustomerID
               select new MyCustomerResult
               {
                  CustomerID=c.CustomerID,
                  CustomerName=c.CustomerName,
                  OrderDate=o.OrderDate
               }
      
         return q;
    }
