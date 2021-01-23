    var result = new StringBuilder();
    foreach (var item in data.AsSmartEnumerable())
    {
        result.Append(item.Value);
        if (!item.IsLast)
        {
            result.Append(", ");
        }
    }
