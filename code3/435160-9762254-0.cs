    foreach (var property in sourceType.GetProperties( BindingFlags.Public | BindingFlags.Instance))
    {
         var targetProperty = targetType.GetProperty( property.Name, BindingFlags.Public | BindingFlags.Instance );
         if (targetProperty != null
              && targetProperty.CanWrite
              && targetProperty.IsAssignableFrom(property.PropertyType))
         {
             targetProperty.SetValue( target, property.GetValue(source, null), null );
         }
    }
