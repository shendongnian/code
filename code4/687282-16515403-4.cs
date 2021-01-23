    public static void ClearAllStaticValues(Type t)
    {
        var varList = t.GetFields(BindingFlags.NonPublic | BindingFlags.Static);
        varList.Where(x => x.FieldType == typeof(Int32)).ToList().ForEach(x => x.SetValue(null, 0)); 
    }
