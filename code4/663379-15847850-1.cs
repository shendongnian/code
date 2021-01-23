    public static string ToDescription(this Categories c)
    {
        var field = typeof(Categories).GetFields().FirstOrDefault(f => (Categories)f.GetValue() == c);
        if (field != null)
        {
            return field.GetCustomAttributes().Cast<DescriptionAttribute>().First().Description;
        }
    }
    ...
    Categories.F2.ToDescription() == "F | F2";
