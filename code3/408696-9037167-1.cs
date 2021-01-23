                    // Start with all public instance properties of type
    var accessors = from property in type.GetProperties
                             (BindingFlags.Instance | BindingFlags.Public)
               
                    // Property must be readable
                    where property.CanRead
                
                    //Assemble expression tree of the form:
                    // foo => (object) foo.Property
                    // foo
                    let parameter = Expression.Parameter(type, "foo")
                    
                    // foo.Property 
                    let propertyEx = Expression.Property(parameter, property)
                   
                    // (object)foo.Property - We need this conversion
                    // because the property may be a value-type.
                    let body = Expression.Convert(propertyEx, typeof(object))
                    // foo => (object) foo.Property
                    let expr = Expression.Lambda<Func<T,object>>(body, parameter)
                    
                    // Compile tree to Func<T,object> delegate
                    select expr.Compile();
    return accessors.ToList();
