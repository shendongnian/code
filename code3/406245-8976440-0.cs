    public void CopyTo(this object source, object target)
    {
        // Argument-checking here...
        // Collect compatible properties and source values
        var tuples = from sourceProperty in source.GetType().GetProperties()
                     join targetProperty in target.GetType().GetProperties() 
                                         on sourceProperty.Name 
                                         equals targetProperty.Name
    
                     // Exclude indexers
                     where !sourceProperty.GetIndexParameters().Any()
                        && !targetProperty.GetIndexParameters().Any()
    
                     // Must be able to read from source and write to target.
                     where sourceProperty.CanRead && targetProperty.CanWrite
    
                     // Property types must be compatible.
                     where targetProperty.PropertyType
                                         .IsAssignableFrom(sourceProperty.PropertyType)
    
                     select new
                     {
                         Value = sourceProperty.GetValue(source, null),
                         Property = targetProperty
                     };
    
        // Copy values over to target.
        foreach (var valuePropertyTuple in tuples)
        {
            valuePropertyTuple.Property
                              .SetValue(target, valuePropertyTuple.Value, null);
    
        }
    }
