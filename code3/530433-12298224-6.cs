    public string StringToLinqQuery<TEnum>(string field, string value) where TEnum : struct
    {
        if (String.IsNullOrWhiteSpace(value))
            return String.Empty;
    
        var valueArray = value.Split('|');
        var query = new StringBuilder();
    
        for (int i = 0; i < valueArray.Count(); i++)
        {
            TEnum result;
            if (Enum.TryParse<TEnum>(valueArray[i].ToLower(), true, out result))
            {
                if (i > 0)
                    query.Append(" OR ");
                query.AppendFormat("{0} == {1}", field, Convert.ToInt32(result));
            }
            else
            {
                throw new DynoException("Item '" + valueArray[i] + "' not found. (" + type of (TEnum) + ")",
                                        query.ToString());
            }
        }
    
        // Wrap field == value with parentheses ()
        query.Insert(0, "(");
        query.Insert(query.Length, ")");
    
        return query.ToString();
    }
