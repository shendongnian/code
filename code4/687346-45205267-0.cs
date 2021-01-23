    public static Func<T, T> DynamicSelectGenerator<T>()
                {
                    // get Properties of the T
                    var fields = typeof(T).GetProperties().Select(propertyInfo => propertyInfo.Name).ToArray();
    
                // input parameter "o"
                var xParameter = Expression.Parameter(typeof(T), "o");
    
                // new statement "new Data()"
                var xNew = Expression.New(typeof(T));
    
                // create initializers
                var bindings = fields.Select(o => o.Trim())
                    .Select(o =>
                    {
    
                        // property "Field1"
                        var mi = typeof(T).GetProperty(o);
    
                        // original value "o.Field1"
                        var xOriginal = Expression.Property(xParameter, mi);
    
                        // set value "Field1 = o.Field1"
                        return Expression.Bind(mi, xOriginal);
                    }
                );
    
                // initialization "new Data { Field1 = o.Field1, Field2 = o.Field2 }"
                var xInit = Expression.MemberInit(xNew, bindings);
    
                // expression "o => new Data { Field1 = o.Field1, Field2 = o.Field2 }"
                var lambda = Expression.Lambda<Func<T, T>>(xInit, xParameter);
    
                // compile to Func<Data, Data>
                return lambda.Compile();
            }
