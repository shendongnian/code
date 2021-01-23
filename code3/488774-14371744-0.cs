    // Check if a poco represents a new record
            public bool IsNew(string primaryKeyName, object poco)
            {
                var pd = PocoData.ForObject(poco, primaryKeyName);
                object pk;
                PocoColumn pc;
                if (pd.Columns.TryGetValue(primaryKeyName, out pc))
                {
                    pk = pc.GetValue(poco);
                }
    #if !PETAPOCO_NO_DYNAMIC
                else if (poco.GetType() == typeof(System.Dynamic.ExpandoObject))
                {
                    return true;
                }
    #endif
                else if (primaryKeyName.Contains(","))
                {
                    return primaryKeyName.Split(',')
                        .Select(pkPart => GetValue(pkPart, poco))
                        .Any(pkValue => IsDefaultOrNull(pkValue));
                }
                else
                {
                    pk = GetValue(primaryKeyName, poco);
                }
    
                return IsDefaultOrNull(pk);
            }
    
            private static object GetValue(string primaryKeyName, object poco)
            {
                object pk;
                var pi = poco.GetType().GetProperty(primaryKeyName);
                if (pi == null)
                    throw new ArgumentException(
                        string.Format("The object doesn't have a property matching the primary key column name '{0}'",
                                      primaryKeyName));
                pk = pi.GetValue(poco, null);
                return pk;
            }
    
            private static bool IsDefaultOrNull(object pk)
            {
                if (pk == null)
                    return true;
    
                var type = pk.GetType();
    
                if (type.IsValueType)
                {
                    // Common primary key types
                    if (type == typeof(long))
                        return (long)pk == default(long);
                    else if (type == typeof(ulong))
                        return (ulong)pk == default(ulong);
                    else if (type == typeof(int))
                        return (int)pk == default(int);
                    else if (type == typeof(uint))
                        return (uint)pk == default(uint);
                    else if (type == typeof(Guid))
                        return (Guid)pk == default(Guid);
    
                    // Create a default instance and compare
                    return pk == Activator.CreateInstance(pk.GetType());
                }
                else
                {
                    return pk == null;
                }
            }
