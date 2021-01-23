    public static IEnumerable<object> OfType(this List<object> list, 
                                             string typeName, CastOptions options)
    {
        Type type = Type.GetType(typeName);
    
        foreach (var obj in list)
        {
            if (Object.ReferenceEquals(obj, null))
            {
                if (options.HasFlag(CastOptions.ExcludeNulls))
                    continue;
    
                yield return obj;
            }
    
            var objectType = obj.GetType();
    
            // Derived type?
            if (type.IsAssignableFrom(objectType))
                yield return obj;
            // Should we try to convert?
            if (!options.HasFlag(CastOptions.UseConversions))
                continue;
            // Castable?
            object convertedValue = null;
    
            try
            {
                var method = typeof(CastExtensions)
                    .GetMethod("Cast", BindingFlags.Static|BindingFlags.NonPublic)
                    .MakeGenericMethod(type);
    
                convertedValue = method.Invoke(null, new object[] { obj });
            }
            catch (InvalidCastException)
            {
                // No implicit/explicit conversion operators
            }
    
            if (convertedValue != null)
                yield return convertedValue;
    
            // Convertible?
            if (options.HasFlag(CastOptions.UseConversions))
            {
                try
                {
                    IConvertible convertible = obj as IConvertible;
                    if (convertible != null)
                        convertible.ToType(type, CultureInfo.CurrentCulture);
                }
                catch (Exception)
                {
                    // Exact exception depends on the source object type
                }
            }
        }
    }
