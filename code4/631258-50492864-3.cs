    private static T CastAs<T>(Dictionary<string, object> source, Dictionary<string, string> mappingTable = null)
    {
        T outputData = (T)Activator.CreateInstance(typeof(T));
        TrySet<T>(outputData, source, mappingTable);
        return outputData;
    }
    private static void TrySet<T>(T target, Dictionary<string, object> source, Dictionary<string, string> mappingTable = null)
    {
        if (target == null)
        {
            throw new ArgumentNullException("target");
        }
        bool useMappingTable = mappingTable != null && mappingTable.Count > 0;
        foreach (KeyValuePair<string, object> kv in source)
        {
            string propertyName = null;
            if (useMappingTable && mappingTable.ContainsKey(kv.Key))
            {
                propertyName = mappingTable[kv.Key];
            }
            else
            {
                propertyName = kv.Key;
            }
            if (!string.IsNullOrEmpty(propertyName))
            {
                UpdateMember(target, propertyName, kv.Value);
            }
        }
    }
    private static void UpdateMember(object target, string propertyName, object value)
    {
        try
        {
            bool isNullable = false;
            Type targetType = null;
            FieldInfo fieldInfo = target.GetType().GetField(propertyName);
            if (fieldInfo != null)
            {
                if (fieldInfo.FieldType.IsGenericType && fieldInfo.FieldType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    isNullable = true;
                    targetType = fieldInfo.FieldType.GetGenericArguments()[0];
                }
                else
                {
                    targetType = fieldInfo.FieldType;
                }
                value = ConvertTo(value, targetType, isNullable);
                fieldInfo.SetValue(target, value);
            }
            else
            {
                PropertyInfo propInfo = target.GetType().GetProperty(propertyName);
                if (propInfo != null)
                {
                    if (propInfo.PropertyType.IsGenericType && propInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        isNullable = true;
                        targetType = propInfo.PropertyType.GetGenericArguments()[0];
                    }
                    else
                    {
                        targetType = propInfo.PropertyType;
                    }
                    value = ConvertTo(value, targetType, isNullable);
                    propInfo.SetValue(target, value);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private static object ConvertTo(object value, Type objType, bool isNullable = false)
    {
        try
        {
            if (isNullable && string.IsNullOrWhiteSpace(Convert.ToString(value)))
            {
                return null;
            }
            else if (objType == typeof(object))
            {
                return value;
            }
            else if (IsCollection(value))
            {
                Type elementType = GetCollectionElementType(objType);
                if (elementType != null)
                {
                    if (objType.BaseType == typeof(Array))
                    {
                        return ConvertToArray(elementType, value);
                    }
                    else
                    {
                        return ConvertToList(elementType, value);
                    }
                }
                else
                {
                    //if we cannot determine the Type of the collection elements
                    //throw an exception to return the default value
                    throw new NullReferenceException();
                }
            }
            else
            {
                return ChangeType(value, objType);
            }
        }
        catch (Exception ex)
        {
            //if we cannot cast the object to the target type, 
            //if the object is a value type, return the default(T), in this case
            //we use Activator.CreateInstance for this purpose, otherwise just return null
            if (objType.IsValueType)
            {
                return Activator.CreateInstance(objType);
            }
            return null;
        }
    }
    private static bool IsCollection(object obj)
    {
        bool isCollection = false;
        Type objType = obj.GetType();
        if (!typeof(string).IsAssignableFrom(objType) && typeof(IEnumerable).IsAssignableFrom(objType))
        {
            isCollection = true;
        }
        return isCollection;
    }
    private static Type GetCollectionElementType(Type objType)
    {
        Type elementType;
        Type[] genericArgs = objType.GenericTypeArguments;
        if (genericArgs.Length > 0)
        {
            elementType = genericArgs[0];
        }
        else
        {
            elementType = objType.GetElementType();
        }
        return elementType;
    }
    private static Array ConvertToArray(Type elementType, object value)
    {
        Array collection = Array.CreateInstance(elementType, ((ICollection)value).Count);
        int i = 0;
        foreach (object item in (IEnumerable)value)
        {
            try
            {
                collection.SetValue(ConvertTo(item, elementType), i);
                i++;
            }
            catch (Exception ex)
            {
                //nothing here, just skip the item
            }
        }
        return collection;
    }
    private static IList ConvertToList(Type elementType, object value)
    {
        var listType = typeof(List<>);
        var constructedListType = listType.MakeGenericType(elementType);
        IList collection = (IList)Activator.CreateInstance(constructedListType);
        foreach (object item in (IEnumerable)value)
        {
            try
            {
                collection.Add(ConvertTo(item, elementType));
            }
            catch (Exception ex)
            {
                //nothing here, just skip the item
            }
        }
        return collection;
    }
    private static object ChangeType(object value, Type castTo)
    {
        try
        {
            return Convert.ChangeType(value, castTo);
        }
        catch (Exception ex)
        {
            //if the conversion failed, just return the original value
            return value;
        }
    }
