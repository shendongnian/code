    static void Prepare(params Type[] types)
            {
                foreach (var type in types)
                {
                    if (type != null && !RuntimeTypeModel.Default.IsDefined(type))
                    {
                        if (type.Namespace.StartsWith("System"))
                            return;
    
                        Debug.WriteLine("Preparing: " + type.FullName);
                        // note this has no defined sort, so invent one
                        var props = type.GetProperties();
                        Array.Sort(props, (x, y) => string.Compare(
                            x.Name, y.Name, StringComparison.Ordinal));
                        var meta = RuntimeTypeModel.Default.Add(type, false);
                        int fieldNum = 1;
                        for (int i = 0; i < props.Length; i++)
                            if (props[i].CanWrite)
                            {                            
                                meta.Add(fieldNum++, props[i].Name);
    
                                if (!RuntimeTypeModel.Default.IsDefined(props[i].PropertyType))
                                    if (props[i].PropertyType.HasElementType)
                                        Prepare(props[i].PropertyType.GetElementType()); //T[]
                                    else if (props[i].PropertyType.IsGenericType)
                                        Prepare(props[i].PropertyType.GetGenericArguments()); //List<T>
                                    else
                                        Prepare(props[i].PropertyType);
                            }
                    }
                }
            }
