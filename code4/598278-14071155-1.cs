    var properties = new List<PropertyInfo>();
    foreach (var property in properties)
    {
        if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType)
            && property.PropertyType.IsGenericType
            && property.PropertyType.GetGenericArguments().Length == 1)
        {
            IList<PropertyInfo> innerProperties = property.PropertyType.GetGenericArguments()[0].GetProperties();
            //should contain properties of elements in lists
        }
        else
        {
            IList<PropertyInfo> innerProperties = property.PropertyType.GetProperties();
            //should contain properties of elements not in a list
        }
    }
