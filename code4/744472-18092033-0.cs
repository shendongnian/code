    static string NonNullField(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException("No information for connection string...");
        return value;
    }
