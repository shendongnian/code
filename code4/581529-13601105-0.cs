    var item = new MyClass();
    // Populate the values somehow
    var result = item.GetType().GetProperties()
        .Where(pi => pi.PropertyType == typeof(Int32))
        .Select(pi => Convert.ToInt32(pi.GetValue(item, null)))
        .Sum();
