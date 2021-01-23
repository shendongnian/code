    public static LambdaExpression PropertyEqual<T>(Type tEntityType, string propertyName, Expression<Func<T>> getValue)
    {
       // entity => entity.PropName == const
       var itemParameter = Expression.Parameter(tEntityType, "entity");
       return Expression.Lambda
       (
           Expression.Equal
           (
               Expression.Property
               (
                   itemParameter,
                   propertyName
               ),
               Expression.Invoke(getValue) // You could directly use getValue.Body instead of Expression.Invoke(getValue)
           ),
           new[] { itemParameter }
       );
    }
