    var method = this.GetType().GetMethod("ValidateProperty");
    foreach (var prop in unitProperties)
    {
        var parameter = Expression.Parameter(this.GetType(), "_");
        var property = Expression.Property(parameter, prop);
        var lambda = Expression.Lambda(property, parameter);
        var genericMethod = method.MakeGenericMethod(prop.PropertyType);
        genericMethod.Invoke(this, new object[] { lambda, prop.GetValue(this, null) });
    }
