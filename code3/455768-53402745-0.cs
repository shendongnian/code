    public static string NullIf(string value)
    {
        if (String.IsNullOrWhiteSpace(value)) { return null; }
        return value;
    }
