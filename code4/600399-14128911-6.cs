    List<string> values = new List<string>();
    object value = propertyInfo.GetValue(task, null);
    if (value is string)
    {
        values.Add((string) value);
    }
    else if (value is IEnumerable<string>)
    {
        values.AddRange((IEnumerable<string>) value);
    }
    else
    {
        // Do whatever you want if the type doesn't match...
    }
