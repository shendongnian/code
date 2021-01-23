    Type genericComparerType = typeof(Comparer<>);
    Type typedComparerType = genericComparerType.MakeGenericType(new Type[] { type1 });
    PropertyInfo defaultProperty = typedComparerType.GetProperty("Default", BindingFlags.Static | BindingFlags.Public);
    if (defaultProperty != null)
    {
        object defaultComparer = defaultProperty.GetValue(null, null);
        MethodInfo method = defaultComparer.GetType().GetMethod("Compare", new Type[] { type1, type1 });
        if (method != null)
        {
            int compareResult = (int)method.Invoke(defaultComparer, new object[] { cell1, cell2 });
        }
    }
