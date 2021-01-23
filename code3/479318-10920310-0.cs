    public static IQueryable<T> FilterByDate(this IQueryable<T> This, Expression<Func<T, DateTime>> getProperty, DateTime date)
    {
      DateTime from = day.Date;
      DateTime to = day.Date.AddDays(1);
      return This.Where(x=> 
        Expression.And(
          Expression.GreaterThan(getProperty, Expression.Variable(from)),
          Expression.LessThan(getProperty, Expression.Variable(to)));
    }
