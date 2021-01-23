    IQueryable<Customer> myQuery = ...
    
    foreach(Customer c in myQuery)  //enumerating the query causes it to be executed
    {
    
    }
    
    List<Customer> customers = myQuery.ToList();
      // ToList will enumerate the query, and put the results in a list.
      // enumerating the query causes it to be executed.
