    var accessors = from property in type.GetProperties
                             (BindingFlags.Instance | BindingFlags.Public)
                    where property.CanRead
                    let parameter = Expression.Parameter(type)
                    let propertyEx = Expression.Property(parameter, property)
                    let body = Expression.Convert(propertyEx, typeof(object))
                    select Expression.Lambda<Func<T,object>>(body, parameter)
                                     .Compile();
    return accessors.ToList();
