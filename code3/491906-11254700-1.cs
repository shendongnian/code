    public static string GetHierarchy(Type t)
    {
        if (t == null)
        {
            return "";
        }
        string rec = GetHierarchy(t.BaseType);
        return rec + "." + t.Name.ToString();
    }
