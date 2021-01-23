    public static bool HasProperty(dynamic obj, string name)
    {
        Type objType = obj.GetType();
        if (objType == typeof(ExpandoObject))
        {
            return ((IDictionary<string, object>)obj).ContainsKey("View");
        }
        return objType.GetProperty(name) != null;
    }
