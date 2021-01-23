    public static string ToStringOrDefault(this object input, string defaultValue)
    {
        return input == null ? defaultValue : input.ToString();
    }
    ...
    string y = Session["key"].ToStringOrDefault("none");
