    public static void ProcessAllStrings(dynamic objToRip)
    {
        if (objToRip == null) return;
        BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        Type typeParameterType = objToRip.GetType();
        foreach (PropertyInfo p in typeParameterType.GetProperties(flags))
        {
            Type currentNodeType = p.PropertyType;
            if (currentNodeType == typeof(String))
            {
                //here I do my custom string handling. Code deleted
            }
            else if (currentNodeType != typeof(object) && Type.GetTypeCode(currentNodeType) == TypeCode.Object)
            {
                ProcessAllStrings(p.GetValue(objToRip, null));
            }
        }
    }
