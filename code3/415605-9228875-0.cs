      SomeStructure GetFromObject(object o)
        { var tt = new Stack<Helper>();
                types.Push(new Helper { Type = o.GetType(), Name = string.Empty });
    
                while (tt.Count > 0)
                {
                    Helper tHelper = tt.Pop();
                    Type t = tHelper.Type;
                    ProcessTheResults( add to a list, whatever ...);
                    if (t.IsValueType || t == typeof(string))
                        continue;
    
                    if (t.IsGenericType)
                    {
                        foreach (var arg in t.GetGenericArguments())
                            tt.Push(new Helper { Type = arg, Name = string.Empty });
                        continue;
    
                    }
    
                    foreach (var propertyInfo in t.GetProperties())
                    {
                        tt.Push(new Helper { Type = propertyInfo.PropertyType, Name = propertyInfo.Name });
    
                    }
                }
    
                return result;
            }
