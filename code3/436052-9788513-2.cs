    // Method:
    public static string ToStringOrDefault(this object input, string defaultValue)
    {
        return input == null ? defaultValue : input.ToString();
    }
    // Example:
    string y = Session["key"].ToStringOrDefault("none");
