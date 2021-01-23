    IDictionary list = source.GetType().GetProperty(dictionaryName).GetValue(source, null) as IDictionary;
    if (!list.Contains(property))
    {
        Type[] arguments = list.GetType().GetGenericArguments();
        list.Add(property, Activator.CreateInstance(arguments[1]));
    }
