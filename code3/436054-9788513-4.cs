    public static string NullPreservingToString(this object input)
    {
        return input == null ? null : input.ToString();
    }
    ...
    string y = Session["key"].NullPreservingToString() ?? "none";
