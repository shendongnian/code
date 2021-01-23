    Type[] types = list.GetType().GetGenericArguments();
    if (types.Length == 1 && types[0] == typeof(int))
    {
        ...
    }
