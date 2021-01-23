    Type genericComparableType = typeof(IComparable<>);
    Type typedComparableType = genericComparableType.MakeGenericType(new Type[] { type1 });
    if (typedComparableType.IsInstanceOfType(cell1))
    {
        MethodInfo method = typedComparableType.GetMethod("CompareTo", new Type[] { type1 });
        if (method != null) 
        {
            int compareResult = (int)method.Invoke(cell1, new object[] { cell2 });
        }
    }
