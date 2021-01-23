    public static IList<T> ParseExpression<T>(string Condition, string FilterColumn) where T:class
    {
      var query = dbContext
                  .CreateObjectSet<T>()
                  .AsQueryable();
      //add filters etc.
      return query.ToList();
    }
