    private static void LoadColors()
    {
        var t = typeof(Colors);
        var ti = t.GetTypeInfo();
        var dp = ti.DeclaredProperties;
        colors = new List<PropertyInfo>();
        foreach (var item in dp)
        {
            colors.Add(item);
        }
    }
    private static List<PropertyInfo> colors;
    public List<PropertyInfo> Colors
    {
        get
        {
            if (colors == null)
                LoadColors();
            return colors;
        }
    }
