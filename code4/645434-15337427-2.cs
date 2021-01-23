    foreach (var item in data.AsSmartEnumerable())
    {
        if (!item.IsFirst)
        {
            result.Append(", ");
        }
        result.Append(item.Value);
    }
