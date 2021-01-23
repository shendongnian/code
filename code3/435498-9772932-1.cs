    public static T To<T>(this object value)
    {
        Type t = typeof(T);
        // Get the type that was made nullable.
        Type valueType = Nullable.GetUnderlyingType(typeof(T));
        if (valueType != null)
        {
            // Nullable type.
            
            if (value == null)
            {
                // you may want to do something different here.
                return default(T);
            }
            else
            {
                // Convert to the value type.
                object result = Convert.ChangeType(value, valueType);
            
                // Cast the value type to the nullable type.
                return (T)result;
            }
        }
        else 
        {
            // Not nullable.
            return (T)Convert.ChangeType(value, typeof(T));
        }
    } 
