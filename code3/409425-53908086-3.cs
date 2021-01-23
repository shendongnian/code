    public static class Extensions
    {
    
       public static int GetOrder<T,TProp>(this T Class, Expression<Func<T,TProp>> propertySelector)
       {
          var body = (MemberExpression)propertySelector.Body;
          var propertyInfo = (PropertyInfo)body.Member;
          return propertyInfo.Order<T>();
       }
    
       public static int Order<T>(this PropertyInfo propertyInfo)
       {
          return typeof(T).GetProperties()
                          .Where(property => Attribute.IsDefined(property, typeof(OrderAttribute)))
                          .OrderBy(property => property.GetCustomAttributes<OrderAttribute>().Single().Order)
                          .ToList()
                          .IndexOf(propertyInfo);
       }
    }
