    public static PropertyPart
       ConstantValue<TType, TValue>(this ClasslikeMapBase<TType> map, TValue value)
    {
        var getter =
            new ConstantValueGetter<TValue>(CreateUniqueMemberName(), value);
        ConstantValueAccessor.RegisterGetter(typeof(TType), getter);
        var propertyInfo =
            new GetterSetterPropertyInfo(typeof(TType), typeof(TValue), 
                                         getter.PropertyName, getter.Method, null);
        var parameter = Expression.Parameter(typeof(TType), "x");
        Expression body = Expression.Property(parameter, propertyInfo);
        body = Expression.Convert(body, , typeof(object));
        var lambda = Expression.Lambda<Func<TType, object>>(body, parameter);
        return map.Map(lambda).Access.Using<ConstantValueAccessor>();
    }
    public static PropertyPart
       ConstantValue<TType, TValue>(this ClasslikeMapBase<TType> map,
                                    TValue value, string column)
    {
        return map.ConstantValue(value).Column(column);
    }
