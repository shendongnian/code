    public sealed override string ToString()
    {
        var allStrings = GetType().GetProperties()
            .Select(p => p.Name + ": " + p.GetValue(this, null));
        return "[" + string.Join("; ", allStrings) + ";]";
    }
