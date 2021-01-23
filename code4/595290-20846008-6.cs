    public static IEnumerable<String> GetNames(IEnumerable<Object> objects, string nameProperty = "Name")
    {
        foreach (var instance in objects)
        {
            var type = instance.GetType();
            var property = type.GetProperty(nameProperty);
            yield return property.GetValue(instance, null) as string;
        }
    }
