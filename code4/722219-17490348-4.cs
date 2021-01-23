    public static object Sum(this IQueryable source, string member)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (member == null) throw new ArgumentNullException(nameof(member));
        // The most common variant of Queryable.Sum() expects a lambda.
        // Since we just have a string to a property, we need to create a
        // lambda from the string in order to pass it to the sum method.
        // Lets create a ((TSource s) => s.Price ). First up, the parameter "s":
        ParameterExpression parameter = Expression.Parameter(source.ElementType, "s");
        // Followed by accessing the Price property of "s" (s.Price):
        PropertyInfo property = source.ElementType.GetProperty(member);
        MemberExpression getter = Expression.MakeMemberAccess(parameter, property);
        // And finally, we create a lambda from that. First specifying on what
        // to execute when the lambda is called, and finally the parameters of the lambda.
        Expression selector = Expression.Lambda(getter, parameter);
        
        // There are a lot of Queryable.Sum() overloads with different
        // return types  (double, int, decimal, double?, int?, etc...).
        // We're going to find one that matches the type of our property.
        MethodInfo sumMethod = typeof(Queryable).GetMethods().First(
            m => m.Name == "Sum"
                 && m.ReturnType == property.PropertyType
                 && m.IsGenericMethod);
        // Now that we have the correct method, we need to know how to call the method.
        // Note that the Queryable.Sum<TSource>(source, selector) has a generic type,
        // which we haven't resolved yet. Good thing is that we can use copy the one from
        // our initial source expression.
        var genericSumMethod = sumMethod.MakeGenericMethod(new[] { source.ElementType });
        // TSource, source and selector are now all resolved. We now know how to call
        // the sum-method. We're not going to call it here, we just express how we're going
        // call it.
        var callExpression = Expression.Call(
            null,
            genericSumMethod,
            new[] {source.Expression, Expression.Quote(selector)});
        // Pass it down to the query provider. This can be a simple LinqToObject-datasource,
        // but also a more complex datasource (such as LinqToSql). Anyway, it knows what to
        // do.
        return source.Provider.Execute(callExpression);
    }
