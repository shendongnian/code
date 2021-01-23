    public static T Clone<T>(this T o) where T : new()
    {
        return (T)CloneObject(o);
    }
    static object CloneObject(object obj)
    {
        if (ReferenceEquals(obj, null)) return null;
    
        var type = obj.GetType();
        if (type.IsValueType || type == typeof(string))
            return obj;
        else if (type.IsArray)
        {
            var array = obj as Array;
            var arrayType = Type.GetType(type.FullName.Replace("[]", string.Empty));
            var arrayInstance = Array.CreateInstance(arrayType, array.Length);
    
            for (int i = 0; i < array.Length; i++)
                arrayInstance.SetValue(CloneObject(array.GetValue(i)), i);
            return Convert.ChangeType(arrayInstance, type);
        }
        else if (type.IsClass)
        {
            var instance = Activator.CreateInstance(type);
            var fields = type.GetFields(BindingFlags.Public |
                        BindingFlags.NonPublic | BindingFlags.Instance);
    
            foreach (var field in fields)
            {
                var fieldValue = field.GetValue(obj);
                if (ReferenceEquals(fieldValue, null)) continue;
                field.SetValue(instance, CloneObject(fieldValue));
            }
            return instance;
        }
        else
            return null;
    }
