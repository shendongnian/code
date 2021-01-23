    PropertyInfo propertyInfo = typeof(Task).GetProperty(type.ToString());
    List<string> values = new List<string>();
    
    object p = propertyInfo.GetValue(task, null);
    if(p is string)
    {
        values.Add((string)p);
    }
    else if(p is List<string>)
    {
        values.AddRange((List<string>)p);
    }
