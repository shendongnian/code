    var properties = type.GetProperties()
                          .Where(prop => prop.IsDefined(typeof(CombinationsAttribute), false));
    foreach(var prop in properties)
    {
        allCombinations.Add(instance);
        var attributes = (CombinationsAttribute[])prop.GetCustomAttributes(typeof(CombinationsAttribute), false);
        foreach(var value in attributes)
        {
        }
    }
