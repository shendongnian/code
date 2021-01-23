    public static string GetType(object data)
    {
        Type type = data.GetType();
        return Convert.ChangeType(data, type).GetType().Name;
    }
