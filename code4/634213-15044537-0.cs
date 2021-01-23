    public void SaveData(string field, string value, Venue v)
    {
        var typeinfo = v.GetType().GetTypeInfo();
        var pi = typeinfo.GetDeclaredProperty(field);
        if (pi != null && pi.Name != "Coordinate")
           pi.SetValue(v, value);
    }
