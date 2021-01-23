    public static class Helper
    {
      public static IEnumerable<T> BuildOrderBys<T>(
        this IEnumerable<T> source,
        string[] properties)
      {
        Type t = typeof(T);
        var propertyInfos = properties
          .Select(prop => t.GetProperty(prop));
        IOrderedEnumerable<T> result = null;
        var thenBy = false;
        foreach (var propertyInfo in propertyInfos)
        {
          var oExpr = Expression.Parameter(typeof(T), "o");
          if (thenBy)
          {
            var prevExpr = Expression.Parameter(typeof(IOrderedEnumerable<T>), "prevExpr");
            var expr1 = Expression.Lambda<Func<IOrderedEnumerable<T>, IOrderedEnumerable<T>>>(
              Expression.Call(
                thenByMethod.MakeGenericMethod(typeof(T), propertyInfo.PropertyType),
                prevExpr,
                Expression.Lambda(
                  typeof(Func<,>).MakeGenericType(typeof(T), propertyInfo.PropertyType),
                  Expression.MakeMemberAccess(oExpr, propertyInfo),
                  oExpr)
                ),
              prevExpr)
              .Compile();
            result = expr1(result);
          }
          else
          {
            var prevExpr = Expression.Parameter(typeof(IEnumerable<T>), "prevExpr");
            var expr1 = Expression.Lambda<Func<IEnumerable<T>, IOrderedEnumerable<T>>>(
              Expression.Call(
                orderByMethod.MakeGenericMethod(typeof(T), propertyInfo.PropertyType),
                prevExpr,
                Expression.Lambda(
                  typeof(Func<,>).MakeGenericType(typeof(T), propertyInfo.PropertyType),
                  Expression.MakeMemberAccess(oExpr, propertyInfo),
                  oExpr)
                ),
              prevExpr)
              .Compile();
            result = expr1(source);
            thenBy = true;
          }
        }
        return result;
      }
      private static MethodInfo orderByMethod =
        MethodOf(() => Enumerable.OrderBy(default(IEnumerable<object>), default(Func<object, object>)))
          .GetGenericMethodDefinition();
      private static MethodInfo thenByMethod =
        MethodOf(() => Enumerable.ThenBy(default(IOrderedEnumerable<object>), default(Func<object, object>)))
          .GetGenericMethodDefinition();
      public static MethodInfo MethodOf<T>(Expression<Func<T>> method)
      {
        MethodCallExpression mce = (MethodCallExpression)method.Body;
        MethodInfo mi = mce.Method;
        return mi;
      }
    }
    public static class Sample
    {
      private static void Main()
      {
        var data = new List<Customer>
          {
            new Customer {ID = 4},
            new Customer {ID = 3, Name = "c"},
            new Customer {ID = 3, Name = "b"},
            new Customer {ID = 3, Name = "a"},
            new Customer {ID = 2}
          };
        var result = data.BuildOrderBys(new[] { "ID", "Name" }).Dump();
      }
      public class Customer
      {
        public int ID { get; set; }
        public string Name { get; set; }
      }
    }
