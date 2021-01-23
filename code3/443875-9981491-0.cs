    if (typeof(IEnumerable<IRecord>).IsAssignableFrom(propertyValue.GetType()))
    {
        foreach (var property in (IEnumerable<IRecord>)propertyValue)
        {
            var test = property;
        }
    }
