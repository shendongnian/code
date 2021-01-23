        var parameter = Expression.Parameter(typeof(T2));      
        var expressionToConvert =  accessors[0]; //for future loop
   
            var propertyChainDescriptor = expressionToConvert.GetPropertiesNames() 
                 .Aggregate(new { Expression = (Expression)parameterCasted, Type = typeof(T2)},
                     (current, propertyName) =>
                     {
                         var property = current.Type.GetProperty(propertyName);
                         var expression = Expression.Property(current.Expression, property);
                         return new { Expression = (Expression)expression, Type = property.PropertyType };
                     });
            var body = propertyChainDescriptor.Expression;
            if (propertyChainDescriptor.Type.IsValueType)
            {
                body = Expression.Convert(body, typeof(object));
            }
            var t2PropertyRetriver = Expression.Lambda<Func<T2, object>>(body, parameter).Compile();
