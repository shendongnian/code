    public static int GetInt(this XElement source, string name, int defaultValue)
    {
        source = NameCheck(source, name, out name);
        return GetInt(source, source.GetDefaultNamespace() + name, defaultValue);
    }
    
    public static int GetInt(this XElement source, XName name, int defaultValue)
    {
        string value = GetString(source, name, null);
        if(string.IsNullOrEmpty(value))
            return defaultValue;
        return Convert.ToInt32(value);
    }
