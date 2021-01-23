    public static IQueryable<T> GetAllOrRestrict<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> predicate)
    {
           var expression = predicate.Body as BinaryExpression;
    
           var rightPart = expression.Right as MemberExpression;
           var value = GetValue(rightPart);
           var test = value.ToString();
           int val;
           if (Int32.TryParse(value.ToString(), out val))
           {
               if (val != 0)
                   return queryable.Where(predicate);
           }
    
           return queryable;
    }
    
    private static object GetValue(MemberExpression member)
    {
         var objectMember = Expression.Convert(member, typeof(object));
         var getterLambda = Expression.Lambda<Func<object>>(objectMember);
         var getter = getterLambda.Compile();
         return getter();
    }
