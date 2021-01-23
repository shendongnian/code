    protected string GetValue(object obj)
    {
        if (obj == null || DBNull.Value.Equals(obj))
        {
           return String.Empty;
        }
    
        return obj.ToString();
    }
