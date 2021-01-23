    private static string FormatDefaultValue(object value)
    {
        if (value is bool)
        {
            return value.ToLocalString().ToLowerInvariant();
        }
    
        if (value is string)
        {
            return value.ToLocalString();
        }
    
        var asEnumerable = value as IEnumerable;
        if (asEnumerable != null)
        {
            var builder = new StringBuilder();
            foreach (var item in asEnumerable)
            {
                builder.Append(item.ToLocalString());
                builder.Append(" ");
            }
            return builder.Length > 0 ? builder.ToString(0, builder.Length - 1) : string.Empty;
        }
        return value.ToLocalString();
    }
