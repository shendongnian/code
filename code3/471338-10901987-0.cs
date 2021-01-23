    static Expression<Func<PropertyHistory, bool>> IsCurrent = (p) => p.Starts <= DateTime.Now;
 
    [ExpandableMethod]
    public static IQueryable<PropertyHistory> AsOf(this IQueryable<PropertyHistory> source)
    {
      return source.Where(IsCurrent);
    }
