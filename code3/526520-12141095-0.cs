    var items = arr.Where(x => x.GetType() == typeof(IEnumerable<object>));
    foreach (var item in items)
    {
        if (item is List<object>) 
        {
            (item as List<object>).Add("test123");
        }
        else if (item is object[]) {...}
    }
