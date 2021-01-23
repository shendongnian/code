    internal string StringToLinqQuery<TEnum>(string field, string value) where TEnum : struct
    {
        if (String.IsNullOrWhiteSpace(value))
            return String.Empty;
    
        var split = value.Split('|');
    
        string query = "(";
        int items = 0;
    
        foreach (var item in split)
        {
            items++;
    
            TEnum result;
            if (Enum.TryParse<TEnum>(item.ToLower(), true, out result))
            {
                if (items > 1)
                    query += " OR ";
    
                query += String.Format("{0} == {1}", field, Convert.ToInt32(result));
            }
            else
            {
                throw new DynoException("Item '" + item + "' not found. (" + typeof(TEnum) + ")");
            }
        }
    
        query += ")";
    
        return query;
    }
