    IQueryable<County> SearchInCountyNames(params string[] countyNames)
    {
      var predicate = PredicateBuilder.False<County>();
    
      foreach (string countyName in countyNames)
      {
        string name = countyName;
        predicate = predicate.Or(c => c.Name.Contains(name));
      }
      return dataContext.Counties.AsExpandable().Where(predicate);
    }
