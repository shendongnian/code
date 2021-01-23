    string columnValue = rec.GetType().GetProperty(field.Key).GetValue(rec, null).ToString();
    if (!string.IsNullOrEmpty(columnValue))
    {
        if (!col_list.Contains(columnValue)) 
            col_list.Add(columnValue);
    }
