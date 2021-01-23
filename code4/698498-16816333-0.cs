    var parameter = Expression.Parameter(typeof(T));
    var containsMethod = typeof(List<string>).GetMethod("Contains");
    var property = Expression.Property(parameter, propertyName);
    var body = Expression.Call(Expression.Constant(selectedOptions), containsMethod, property);
    condition = Expression.Lambda<Func<T, bool>>(body, parameter);
