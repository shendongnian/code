    var result = new StringBuilder();
    foreach (var item in data.AsSmartEnumerable())
    {
        result.Append(item);
        if (!item.IsLast)
        {
            result.Append(", ");
        }
    }
