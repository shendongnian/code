     public IQueryable<Address> GetAddressesWithTown(string[] towns)
    {
      var predicate = PredicateBuilder.False<Address>();
    
      foreach (string town in towns)
      {
        string temp = town;
        predicate = predicate.Or (p => p.Town.Equals(temp));
      }
      return DbContext.Addresses.Where (predicate);
    }
