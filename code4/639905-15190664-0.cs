    var abc = new[]
    {
        1, 2, 3, 4
    }
    .Select(x = > {
        var xType = x.GetType();
        if (xType.IsValueType)
        {
            return Activator.CreateInstance(xType);
        }
        else
        {
            return null;
        }
    })
