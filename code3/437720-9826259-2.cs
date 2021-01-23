    public static int FindRowNumber<T>(IQueryable<T> query, Expression<Func<T, bool>> search, int skip, int take)
    {
      if(take == 1)
      { 
        return query.Skip(skip).Take(take).Any(search) ? skip : -1;      
      }
      int bottomSkip = skip;
      int bottomTake = take / 2;
      int topSkip = bottomTake + bottomSkip;
      int topTake = take - bottomTake;
      if(query.Skip(bottomSkip).Take(bottomTake).Any(search))
      {        
        return FindRowNumber(query, search, bottomSkip, bottomTake);
      }
      if(query.Skip(topSkip).Take(topTake).Any(search))
      {
        return FindRowNumber(query, search, topSkip, topTake);
      }
      
      return -1;
    }
