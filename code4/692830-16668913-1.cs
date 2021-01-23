    var parameter = Expression.Parameter(typeof(Message), "o");
    var getname = Expression.Property(parameter, "Body");
    var isnullorempty = Expression.Not(Expression.Call(typeof(string), "IsNullOrEmpty", null, getname));
    var compare = Expression.Equal(getname, Expression.Constant("thisvalue"));
    var combined = Expression.And(isnullorempty, compare);
    var lambda = Expression.Lambda(combined, parameter);
