    public static string GetHierarchy(Type t)
    {
        string rec = "";
        if (t.BaseType != null)
        {
            rec = GetHierarchy(t.BaseType);
        }
        return rec + "." + t.Name.ToString();
    }
