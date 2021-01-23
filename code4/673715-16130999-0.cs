    public static List<Color> ColorStructToList()
    {
        return typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                            .Select(c => (Color)c.GetValue(null, null))
                            .ToList();
    }
List<Color> colorList = ColorStructToList();
