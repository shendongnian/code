    List<Func<Customer, bool>> criteria = new List<Func<Customer, bool>>();
    
    criteria.Add(c => c.Name.StartsWith("B"));
    criteria.Add(c => c.Job == Jobs.Plumber);
    criteria.Add(c => c.IsExcellent);
    
    Customer myCustomer = GetCustomer();
    
    int criteriaCount = criteria
      .Where(q => q(myCustomer))
      // .Take(2)  // optimization
      .Count()
    if (criteriaCount == 1)
    {
    }
