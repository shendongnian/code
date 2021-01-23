    private static IQueryable<Result> toResults(IQueryable<WebPage> query)
    {
      return query.Select(item => new Result
      {
      //...
      }
    }
