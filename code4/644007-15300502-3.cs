        // Create and return an expression that maps T => dynamic type
        var sourceItem = Expression.Parameter(sourceType, "item");
        var bindings = dynamicType
            .GetFields()
            .Select(p => Expression.Bind(p, Expression.PropertyOrField(sourceItem, p.Name)))
            .OfType<MemberBinding>()
            .ToArray();
        var fetcher = Expression.Lambda<Func<T, object>>(
            Expression.Convert(
                Expression.MemberInit(
                    Expression.New(dynamicType.GetConstructor(Type.EmptyTypes)),
                    bindings), 
                typeof(object)),
            sourceItem);                
