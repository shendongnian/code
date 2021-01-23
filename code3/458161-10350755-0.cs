    public static string ReplaceFirstOccurrance(string original, string oldValue, string newValue)
    {
        if (String.IsNullOrEmpty(original))
            return String.Empty;
        if (String.IsNullOrEmpty(oldValue))
            return original;
        if (String.IsNullOrEmpty(newValue))
            newValue = String.Empty;
        int loc = original.IndexOf(oldValue);
        return original.Remove(loc, oldValue.Length).Insert(loc, newValue);
    }
