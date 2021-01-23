      var predicate = PredicateBuilder.True<Customer>();
      if (!string.IsNullOrEmpty(FirstName))
      {
           predicate = predicate.And(d => d.FirstName.Contains(FirstName));
      }
    
      if (!string.IsNullOrEmpty(LastName))
      {
           predicate = predicate.And(d => d.LastName.Contains(LastName));
      }
      var products = productRepo.GetAllBy(predicate);
