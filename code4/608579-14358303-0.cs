    List<Customer> list = new List<Customer>();
    List<Func<Customer,bool>> predicateList = new List<Func<Customer,bool>>();
    
    if(/*user choice condition*/)
    {
        predicateList.Add(c => c.Name.Contains("test"));
    }
    if (/*user choice condition*/)
    {
        predicateList.Add(c => c.Name.Contains("test") || c.Description.Contains("buyer"));
    }
    //etc.
    
    
    Expression<Func<IWorkItem, bool>> filterExpression = c => whereClausePredicates.All(pred => pred(c));
    var filteredCustomers = list.Where(filterExpression.Compile());
