    // Method:
    public static string ToStringOrNull(this object input)
    {
        return input == null ? null : input.ToString();
    }
    // Example:
    string y = Session["key"].ToStringOrNull() ?? "none";
