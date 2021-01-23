    public static void Test(string[] args) {
      using (var db = new DBContext()) {
        //query 1
        var query1 = db.PrizeTypes.Where(m => m.rewards == 1000).Select(t => t.name);
        //query 2 which equal to query 1
        Expression<Func<PrizeType, bool>> predicate1 = m => m.rewards == 1000;
        Expression<Func<PrizeType, string>> selector1 = t => t.name;
        var query2 = db.PrizeTypes.Where(predicate1).Select(selector1);
        Console.WriteLine(predicate1);
        Console.WriteLine(selector1);
        Console.WriteLine();
        //query 3 which equal to query 1 and 2
        Expression<Func<PrizeType, bool>> predicate2 = GetPredicateEqual<PrizeType>("rewards", (Int16)1000);
        Expression<Func<PrizeType, string>> selector2 = GetSelector<PrizeType, string>("name");
        var query3 = db.PrizeTypes.Where(predicate2).Select(selector2);
        Console.WriteLine(predicate2);
        Console.WriteLine(selector2);
        //as you can see, query 1 will equal query 2 equal query 3
      }
    }
    public static Expression<Func<TEntity, bool>> GetPredicateEqual<TEntity>(string fieldName, object fieldValue) where TEntity : class {
      ParameterExpression m = Expression.Parameter(typeof(TEntity), "t");
      var p = m.Type.GetProperty(fieldName);
      BinaryExpression body = Expression.Equal(
        Expression.Property(m, fieldName),
        Expression.Constant(fieldValue, p.PropertyType)
      );
      return Expression.Lambda<Func<TEntity, bool>>(body, m);
    }
    public static Expression<Func<T, TReturn>> GetSelector<T, TReturn>(string fieldName)
      where T : class
      where TReturn : class {
      var t = typeof(TReturn);
      ParameterExpression p = Expression.Parameter(typeof(T), "t");
      var body = Expression.Property(p, fieldName);
      return Expression.Lambda<Func<T, TReturn>>(body, new ParameterExpression[] { p });
    }
