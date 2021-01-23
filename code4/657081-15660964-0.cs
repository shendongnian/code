    var color= Expression.Constant(Color.Red);
    var property = Expression.Property(Expression.Parameter(typeof(Shirt)), "Color");
    var colorValue = Expression.Convert(color, Enum.GetUnderlyingType(typeof(Color)));
    var propertyValue = Expression.Convert(property, Enum.GetUnderlyingType(typeof(Color)));
    Expression.NotEqual(Expression.And(propertyValue, colorValue), Expression.Constant(0));
