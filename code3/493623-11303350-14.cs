    Type genericComparableType = typeof(IComparable<>);
    Type typedComparableType = genericComparableType.MakeGenericType(new Type[] { type1 });
    if (typedComparableType.IsInstanceOfType(cell1))
    {
        MethodInfo compareTo = typedComparableType.GetMethod("CompareTo", new Type[] { type1 });
        int compareResult = (int)compareTo.Invoke(cell1, new object[] { cell2 });
    }
