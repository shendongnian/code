    public static string ToDescription(this Categories c)
    {
        var categoryNames =
            from c in Enum.GetValues(typeof(Categories)).Cast<Category>()
            where v & c == c
            orderby v
            select v.ToString();
        return String.Join(", ", categoryNames);
    }
