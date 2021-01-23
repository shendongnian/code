    public static U MapValidValues<U, T>(T source, U destination)
    {
        // Go through all fields of source, if a value is not null, overwrite value on destination field.
        foreach (var propertyName in source.GetType().GetProperties().Where(p => !p.PropertyType.IsGenericType).Select(p => p.Name))
        {
            var value = source.GetType().GetProperty(propertyName).GetValue(source, null);
            if (value != null && (value.GetType() != typeof(DateTime) || (value.GetType() == typeof(DateTime) && (DateTime)value != DateTime.MinValue)))
            {
                destination.GetType().GetProperty(propertyName).SetValue(destination, value, null);
            }
        }
    
        return destination;
    }
