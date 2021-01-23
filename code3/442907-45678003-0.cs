    public static bool HasPropertyExist(dynamic settings, string name)
    {
        if (settings is System.Dynamic.ExpandoObject)
            return ((IDictionary<string, object>)settings).ContainsKey(name);
        if (settings is System.Web.Helpers.DynamicJsonObject)
        try
        {
            return settings[name] != null;
        }
        catch (KeyNotFoundException)
        {
            return false;
        }
        return settings.GetType().GetProperty(name) != null;
    }
