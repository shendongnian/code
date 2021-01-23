    private static T CastAs<T>(Dictionary<string, object> source, Dictionary<string, string> mappingTable = null)
    {
        T outputData = (T)Activator.CreateInstance(typeof(T));
        TrySet(outputData, source, mappingTable);
        return outputData;
    }
    private static void TrySet(object target, Dictionary<string, object> source, Dictionary<string, string> mappingTable = null)
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
                UpdateMember(target, propertyName, kv.Value, mappingTable);
            }
        }
    }
    private static void UpdateMember(object target, string propertyName, object value, Dictionary<string, string> mappingTable)
    {
        try
        {
            FieldInfo fieldInfo = target.GetType().GetField(propertyName);
            if (fieldInfo != null)
            {
                value = ConvertTo(value, fieldInfo.FieldType, mappingTable);
                fieldInfo.SetValue(target, value);
            }
            else
            {
                PropertyInfo propInfo = target.GetType().GetProperty(propertyName);
                if (propInfo != null)
                {
                    value = ConvertTo(value, propInfo.PropertyType, mappingTable);
                    propInfo.SetValue(target, value);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private static object ConvertTo(object value, Type targetType, Dictionary<string, string> mappingTable)
    {
        try
        {
            bool isNullable = false;
            Type sourceType = value.GetType();
            //Obtain actual type to convert to (this is necessary in case of Nullable types)
            if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                isNullable = true;
                targetType = targetType.GetGenericArguments()[0];
            }
            if (isNullable && string.IsNullOrWhiteSpace(Convert.ToString(value)))
            {
                return null;
            }
            //if we are converting from a dictionary to a class, call the TrySet method to convert its members
            else if (targetType.IsClass && sourceType.IsGenericType && sourceType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                //make sure our value is actually a Dictionary<string, object> in order to be able to cast
                if (sourceType.GetGenericArguments()[0] == typeof(string))
                {
                    object convertedValue = Activator.CreateInstance(targetType);
                    TrySet(convertedValue, (Dictionary<string, object>)value, mappingTable);
                    return convertedValue;
                }
                return null;
            }
            else if (IsCollection(value))
            {
                Type elementType = GetCollectionElementType(targetType);
                if (elementType != null)
                {
                    if (targetType.BaseType == typeof(Array))
                    {
                        return ConvertToArray(elementType, value, mappingTable);
                    }
                    else
                    {
                        return ConvertToList(elementType, value, mappingTable);
                    }
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            else if (targetType == typeof(DateTimeOffset))
            {
                return new DateTimeOffset((DateTime)ChangeType(value, typeof(DateTime)));
            }
            else if (targetType == typeof(object))
            {
                return value;
            }
            else
            {
                return ChangeType(value, targetType);
            }
        }
        catch (Exception ex)
        {
            if (targetType.IsValueType)
            {
                return Activator.CreateInstance(targetType);
            }
            return null;
        }
    }
    private static Array ConvertToArray(Type elementType, object value, Dictionary<string, string> mappingTable)
    {
        Array collection = Array.CreateInstance(elementType, ((ICollection)value).Count);
        int i = 0;
        foreach (object item in (IEnumerable)value)
        {
            try
            {
                collection.SetValue(ConvertTo(item, elementType, mappingTable), i);
                i++;
            }
            catch (Exception ex)
            {
                //nothing here, just skip the item
            }
        }
        return collection;
    }
    private static IList ConvertToList(Type elementType, object value, Dictionary<string, string> mappingTable)
    {
        Type listType = typeof(List<>);
        Type constructedListType = listType.MakeGenericType(elementType);
        IList collection = (IList)Activator.CreateInstance(constructedListType);
        foreach (object item in (IEnumerable)value)
        {
            try
            {
                collection.Add(ConvertTo(item, elementType, mappingTable));
            }
            catch (Exception ex)
            {
                //nothing here, just skip the item
            }
        }
        return collection;
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
