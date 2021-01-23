    string text = GetDateString(); // Name converted to follow .NET conventions
    DateTime parsed;
    // This will only try to parse if text is non-null and non-empty
    if (string.IsNullOrEmpty(text) || !DateTime.TryParse(text, out parsed))
    {
        parsed = // some default here
    }
