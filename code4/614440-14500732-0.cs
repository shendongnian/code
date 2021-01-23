    var p = Expression.Parameter(typeof(object));
    var expr = Expression.Lambda<Func<object, object>>(
        Expression.Convert(
            Expression.PropertyOrField(
                 Expression.Convert(p, a.GetType()), propName), typeof(object)), p);
