    public static IEnumerable<object> OfType(this List<object> list, 
                                             string typeName, CastOptions options)
    {
        Type type = Type.GetType(typeName);
    
        foreach (var obj in list)
        {
            if (Object.ReferenceEquals(obj, null))
            {
                if ((options & CastOptions .ExcludeNulls) != CastOptions.None)
                    continue;
    
                yield return obj;
            }
    
            var objectType = obj.GetType();
    
            // Derived type?
            if (type.IsAssignableFrom(objectType))
                yield return obj;
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
            if ((options & CastOptions .UseConversions) != CastOptions.None)
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
