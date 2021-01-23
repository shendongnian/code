    public static IEnumerable<T> AsEnumerable<T>(this string value)
    {
        if (String.IsNullOrEmpty(value))
            yield break;
        var parts = value.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
            yield return Convert.ChangeType(part.Trim(), typeof(T));
    }
