    public static int GetInt(this XElement source, string name, int defaultValue)
    {
        source = NameCheck(source, name, out name);
        return GetInt(source, source.GetDefaultNamespace() + name, defaultValue);
    }
    
    public static int GetInt(this XElement source, XName name, int defaultValue)
    {
        int result;
        if (Int32.TryParse(GetString(source, name, null), out result))
            return result;
        return defaultValue;
    }
