    public static string ToDescription(this Categories c)
    {
        var categoryNames =
            from f in typeof(Categories).GetFields()
            let v = (Categories)f.GetValue(null)
            where v & c == c
            orderby v
            select f.Name;
        return String.Join(", ", categoryNames
    }
