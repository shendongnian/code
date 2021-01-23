    string searchfield, value; // Your inputs
    var param = Expression.Parameter(typeof(User), "user");
    
    return Expression.Lambda<Func<T, bool>>(
        Expression.Call(
            Expression.Property(
                param,
                typeof(User).GetProperty(searchfield)),
            typeof(string).GetMethod("Contains"),
            Expression.Constant(value)),
        param);
