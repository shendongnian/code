    var prop = response.GetType.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
    foreach (var prop in props)
    {
        prop.GetValue(response, null);
    }
