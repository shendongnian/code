    Type genericComparerType = typeof(Comparer<>);
    Type typedComparerType = genericComparerType.MakeGenericType(new Type[] { type1 });
    PropertyInfo defaultProperty = typedComparerType.GetProperty("Default", BindingFlags.Static | BindingFlags.Public);
    object defaultComparer = defaultProperty.GetValue(null, null);
    MethodInfo compare = defaultComparer.GetType().GetMethod("Compare", new Type[] { type1, type1 });
    int compareResult = (int)compare.Invoke(defaultComparer, new object[] { cell1, cell2 });
